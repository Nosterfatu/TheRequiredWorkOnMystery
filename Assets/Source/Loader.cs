using Source;
using UnityEngine;
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
        _progressionManager.SetProgress(progress);
        SceneManager.LoadScene(1);
    }
}