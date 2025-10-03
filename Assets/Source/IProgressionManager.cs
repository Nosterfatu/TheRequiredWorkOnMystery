namespace Source
{
    public interface IProgressionManager
    {
        void SetProgress(int progress);
        void SetLevel(GameSave level);
        void Reset();
    }
}