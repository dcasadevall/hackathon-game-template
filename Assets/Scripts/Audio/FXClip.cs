using UnityEngine;

namespace Audio {
  /// <summary>
  /// A serializable FX Clip class that represents a sound effect in the game.
  /// By assigning an <see cref="AudioClip"/> to an <see cref="FXType"/>, we make sure
  /// there is a unique set of ids representing all clips.
  /// </summary>
  [System.Serializable]
  internal class FXClip : IFXClip {
#pragma warning disable 649
    [SerializeField]
    private AudioClip _clip;
    
    [SerializeField]
    private FXType _fxType;
#pragma warning restore 649
    
    public AudioClip Clip {
      get {
        return _clip;
      }
    }

    public FXType FxType {
      get {
        return _fxType;
      }
    }
  }
}