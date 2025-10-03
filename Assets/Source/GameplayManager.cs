namespace Source
{
    public class GameplayManager
    {
        private readonly SidePanelController _sidePanelController;
        private readonly MetaContext _progressionManager;
        private readonly ILoader _loader;

        public GameplayManager(FieldController fieldController, SidePanelController sidePanelController, MetaContext progressionManager, ILoader loader)
        {
            _sidePanelController = sidePanelController;
            _progressionManager = progressionManager;
            _loader = loader;
            fieldController.FieldChanged += OnFieldChanged;
            fieldController.Won += OnWin;
            fieldController.Lost += OnLoose;
        }

        private void OnLoose()
        {
            _progressionManager.Reset();
            _loader.Load(_progressionManager.Progress);
        }

        private void OnWin()
        {
            _loader.Load(_progressionManager.Progress + 1);
        }

        private void OnFieldChanged(GameSave save)
        {
            _sidePanelController.Update(save);
            _progressionManager.SetLevel(save);
        }
    }
}