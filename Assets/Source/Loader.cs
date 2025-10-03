using Source;
using UnityEngine.SceneManagement;

internal class Loader : ILoader
{
    private readonly IProgressionManager _progressionManager;

    public Loader(IProgressionManager progressionManager)
    {
        _progressionManager = progressionManager;
    }
    
    public void Load(int progress)
    {
        if (progress < 0)
        {
            progress = 0;
            _progressionManager.Reset();
        }
        _progressionManager.SetProgress(progress);
        SceneManager.LoadScene(1);
    }

    public void Unload()
    {
        SceneManager.LoadScene(0);
    }
}