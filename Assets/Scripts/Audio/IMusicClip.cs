using UnityEngine;

namespace Audio {
  /// <summary>
  /// Playable Music clip represented by its unique <see cref="MusicType"/>
  /// </summary>
  public interface IMusicClip {
    AudioClip Clip { get; }
    MusicType MusicType { get; }
  }
}