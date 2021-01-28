using System;
using LogSystem;
using Photon.Pun;
using UniRx;
using UniRx.Async;

namespace Networking.Photon.Connecting {
    internal class PhotonNetworkConnector : IPhotonNetworkConnector {
        private readonly ServerSettings _photonServerSettings;
        private readonly ILogger _logger;

        public PhotonNetworkConnector(ServerSettings photonServerSettings, ILogger logger) {
            _photonServerSettings = photonServerSettings;
            _logger = logger;
        }
        
        public async UniTask Connect(bool allowOfflineMode) {
            _logger.Log(LoggedFeature.Network, "Connecting to USW Server.");
            PhotonNetwork.NetworkingClient.AppId = _photonServerSettings.AppSettings.AppIdRealtime;
            PhotonNetwork.NetworkingClient.AppVersion = _photonServerSettings.AppSettings.AppVersion;
            PhotonNetwork.NetworkingClient.ExpectedProtocol = _photonServerSettings.AppSettings.Protocol;
            PhotonNetwork.ConnectToRegion("usw");

            if (allowOfflineMode) {
                await Observable.EveryUpdate().Where(_ => PhotonNetwork.IsConnectedAndReady).FirstOrDefault()
                                .Timeout(TimeSpan.FromSeconds(5)).CatchIgnore((Exception e) => {
                                    _logger.Log(LoggedFeature.Network, "Starting in offline mode. Connection Exception: {0}", e);
                                    PhotonNetwork.OfflineMode = true;
                                });
            } else {
                await Observable.EveryUpdate().Where(_ => PhotonNetwork.IsConnectedAndReady).FirstOrDefault()
                    .Timeout(TimeSpan.FromSeconds(5));
            }
        }
    }
}