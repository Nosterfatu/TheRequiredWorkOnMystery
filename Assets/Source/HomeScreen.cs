using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour
{
    [SerializeField] Button _buttonContinue;
    [SerializeField] Button _buttonNewGame;
    private IProgressionContext _context;
    private ILoader _loader;

    public void Install(IProgressionContext context, ILoader loader)
    {
        _context = context;
        _loader = loader;
        _buttonContinue. gameObject.SetActive(context.HasProgress);
    }
    
    void Start()
    {
        _buttonContinue.onClick.AddListener(Continue);
        _buttonNewGame.onClick.AddListener(NewGame);
    }

    private void Continue()
    {
        _loader.Load(_context.Progress);
    }

    private void NewGame()
    {
        _loader.Load(0);
    }
}