namespace Audio {
  /// <summary>
  /// Audio player used throughout the game. It should allow playback of music and fx via their unique identifiers.
  /// </summary>
  public interface IAudioPlayer {
    void PlayMusic(MusicType musicType);
    void StopMusic();
    void PlaySoundEffect(FXType fxType);
  }
}