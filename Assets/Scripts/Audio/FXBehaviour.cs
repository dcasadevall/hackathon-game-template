using System.Collections;
using UnityEngine;
using Zenject;

namespace Audio {
  /// <summary>
  /// Poolable Audio clip which can be used to reproduce FX without having to instantiate a new audio clip.
  /// per audio source.
  /// 
  /// It handles Audio Clip lifecycle after the non looped clip has finished playing.
  /// </summary>
  internal class FXBehaviour : MonoBehaviour, IPoolable<AudioClip, IMemoryPool> {
    private AudioSource _audioSource;
    
    public class Factory : PlaceholderFactory<AudioClip, FXBehaviour> {
    }
    
    public void OnSpawned(AudioClip clip, IMemoryPool memoryPool) {
      if (_audioSource == null) {
        _audioSource = gameObject.AddComponent<AudioSource>();
      }

      _audioSource.loop = false;
      _audioSource.clip = clip;
      _audioSource.Play();
      StartCoroutine(DespawnAfterSoundFinishedPlaying(clip, memoryPool));
    }

    private IEnumerator DespawnAfterSoundFinishedPlaying(AudioClip clip, IMemoryPool memoryPool) {
      yield return new WaitForSeconds(clip.length);
      memoryPool.Despawn(this);
    }
    
    public void OnDespawned() {
    }
  }
}