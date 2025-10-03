namespace Source
{
    public interface IProgressionManager : IProgressionContext
    {
        void SetProgress(int progress);
        void SetLevel(GameSave level);
        void Reset();
    }
}