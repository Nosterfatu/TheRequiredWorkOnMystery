namespace Source
{
    public class GameplayManager
    {
        private readonly SidePanelController _sidePanelController;
        private readonly MetaContext _progressionManager;
        private readonly ILoader _loader;
        private readonly IAudioManager _audioManager;

        public GameplayManager(FieldController fieldController, SidePanelController sidePanelController, MetaContext progressionManager, ILoader loader, IAudioManager audioManager)
        {
            _sidePanelController = sidePanelController;
            _progressionManager = progressionManager;
            _loader = loader;
            _audioManager = audioManager;
            fieldController.FieldChanged += OnFieldChanged;
            fieldController.Won += OnWin;
            fieldController.Lost += OnLoose;
        }

        private void OnLoose()
        {
            _audioManager.PlaySound(SFX.Lose);
            _progressionManager.Reset();
            _loader.Load();
        }

        private void OnWin()
        {
            _audioManager.PlaySound(SFX.Win);
            _progressionManager.SetProgress(_progressionManager.Progress + 1);
            _progressionManager.Reset();
            _loader.Load();
        }

        private void OnFieldChanged(GameSave save)
        {
            _sidePanelController.Update(save);
            _progressionManager.SetLevel(save);
        }
    }
}