namespace Source
{
    public interface IAudioManager
    {
        void PlaySound(SFX sfx, float delay = 0);
        void PlayMusic();
    }
    
    public enum SFX
    {
        ButtonClick,
        CardDrow,
        CardHide,
        CardClear,
        Win,
        Lose,
        LevelStarted
    }
    
}