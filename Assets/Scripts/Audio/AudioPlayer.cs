using System.Linq;
using UnityEngine;
using Zenject;

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

    public AudioPlayer(
      FXBehaviour.Factory fxFactory,
      [Inject(Id = AudioInstaller.kMusicSourceId)]
      AudioSource musicSource,
      IFXClip[] fxClips, IMusicClip[] musicClips) {
      _fxFactory = fxFactory;
      _musicSource = musicSource;
      _fxClips = fxClips;
      _musicClips = musicClips;
    }
    
    public void PlayMusic(MusicType musicType) {
      IMusicClip musicClip = _musicClips.FirstOrDefault(x => x.MusicType == musicType);
      if (musicClip == null) {
        Debug.LogFormat($"Music Clip not found: {musicType}");
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
        Debug.LogError(string.Format("FX Clip not found: {0}", fxType));
        return;
      }
      
      _fxFactory.Create(fxClip.Clip);
    }
  }
}