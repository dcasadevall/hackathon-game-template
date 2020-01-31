using UnityEngine;

namespace Audio {
  /// <summary>
  /// Playable FX clip represented by its unique <see cref="FxType"/>
  /// </summary>
  public interface IFXClip {
    AudioClip Clip { get; }
    FXType FxType { get; }
  }
}