using Source;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour
{
    [SerializeField] Button _buttonContinue;
    [SerializeField] Button _buttonNewGame;
    private IProgressionManager _context;
    private ILoader _loader;
    private IAudioManager _audioManager;

    public void Install(IProgressionManager context, ILoader loader, IAudioManager audioManager)
    {
        _context = context;
        _loader = loader;
        _audioManager = audioManager;
        _buttonContinue.gameObject.SetActive(context.HasProgress);
    }
    
    void Start()
    {
        _buttonContinue.onClick.AddListener(Continue);
        _buttonNewGame.onClick.AddListener(NewGame);
    }

    private void Continue()
    {
        _audioManager.PlaySound(SFX.ButtonClick);
        _loader.Load();
    }

    private void NewGame()
    {
        _audioManager.PlaySound(SFX.ButtonClick);
        _context.SetProgress(0);
        _context.Reset();
        _loader.Load();
    }
}