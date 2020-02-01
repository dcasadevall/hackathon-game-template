using System.Linq;
using LogSystem;
using UnityEngine;
using Zenject;
using ILogger = LogSystem.ILogger;

namespace Audio {
  /// <summary>
  /// Implementation of <see cref="IAudioPlayer"/> which uses one music source and multiple fx sources
  /// in order to play music / fx.
  /// </summary>
  internal class AudioPlayer : IAudioPlayer {
    private readonly AudioSource _fxSource;
    private readonly FXBehaviour.Factory _fxFactory;
    private readonly AudioSource _musicSource;
    private readonly IFXClip[] _fxClips;
    private readonly IMusicClip[] _musicClips;
    private readonly ILogger _logger;

    public AudioPlayer(
      FXBehaviour.Factory fxFactory,
      [Inject(Id = AudioInstaller.kMusicSourceId)]
      AudioSource musicSource,
      IFXClip[] fxClips, IMusicClip[] musicClips, 
      ILogger logger) {
      _fxFactory = fxFactory;
      _musicSource = musicSource;
      _fxClips = fxClips;
      _musicClips = musicClips;
      _logger = logger;
    }
    
    public void PlayMusic(MusicType musicType) {
      IMusicClip musicClip = _musicClips.FirstOrDefault(x => x.MusicType == musicType);
      if (musicClip == null) {
        _logger.LogError(LoggedFeature.Audio, $"Music Clip not found: {musicType}");
        return;
      }
      
      _musicSource.clip = musicClip.Clip;
      _musicSource.Play();
    }

    public void StopMusic() {
      _musicSource.Stop();
    }

    public void PlaySoundEffect(FXType fxType) {
      IFXClip fxClip = _fxClips.FirstOrDefault(x => x.FxType == fxType);
      if (fxClip == null) {
        _logger.LogError(LoggedFeature.Audio, $"FX Clip not found: {fxType}");
        return;
      }
      
      _fxFactory.Create(fxClip.Clip);
    }
  }
}