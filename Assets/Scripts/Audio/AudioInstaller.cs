using UnityEngine;
using Zenject;

namespace Audio {
  public class AudioInstaller : MonoInstaller {
    public const string kMusicSourceId = "MusicSourceId";
    
#pragma warning disable 649
    [SerializeField]
    private MusicClip[] _musicClips;
    
    [SerializeField]
    private FXClip[] _fxClips;
#pragma warning restore 649

    public override void InstallBindings() {
      foreach (var musicClip in _musicClips) {
        Container.Bind<IMusicClip>().To<MusicClip>().FromInstance(musicClip);
      }
      
      foreach (var fxClip in _fxClips) {
        Container.Bind<IFXClip>().To<FXClip>().FromInstance(fxClip);
      }

      Container.Bind<AudioSource>().WithId(kMusicSourceId).FromNewComponentOn(gameObject).AsSingle()
               .OnInstantiated((InjectContext injectCtx, AudioSource
                                  audioSource) => {
                 audioSource.playOnAwake = false;
               });

      Container.BindFactory<AudioClip, FXBehaviour, FXBehaviour.Factory>()
               .FromPoolableMemoryPool<AudioClip, FXBehaviour, FXPool>(poolBinder =>
                                                                         poolBinder
                                                                           .WithInitialSize(5)
                                                                           .FromNewComponentOnNewGameObject()
                                                                           .UnderTransformGroup("Sound Effects"));
      Container.Bind<IAudioPlayer>().To<AudioPlayer>().AsSingle();
    }
    
    class FXPool : MonoPoolableMemoryPool<AudioClip, IMemoryPool, FXBehaviour> {
    }
  }
}