using System;
using UnityEngine;

namespace Audio {
  /// <summary>
  /// A serializable Music Clip class that represents background music in the game.
  /// By assigning an <see cref="AudioClip"/> to a <see cref="MusicClip"/>, we make sure
  /// there is a unique set of ids representing all background music.
  /// </summary>
  [Serializable]
  internal class MusicClip : IMusicClip {
#pragma warning disable 649
    [SerializeField]
    private AudioClip _clip;
    
    [SerializeField]
    private MusicType _musicType;
#pragma warning restore 649
    
    public AudioClip Clip {
      get {
        return _clip;
      }
    }

    public MusicType MusicType {
      get {
        return _musicType;
      }
    }
  }
}