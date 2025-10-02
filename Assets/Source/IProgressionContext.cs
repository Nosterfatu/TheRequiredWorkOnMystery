public interface IProgressionContext
{
    public bool HasProgress { get; }
    public int Progress { get; }
    public GameSave Save { get; }
}