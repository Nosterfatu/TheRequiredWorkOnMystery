namespace Source
{
    public class GameplayManager
    {
        private readonly SidePanelController _sidePanelController;
        private readonly IProgressionManager _progressionManager;

        public GameplayManager(FieldController fieldController, SidePanelController sidePanelController, IProgressionManager progressionManager)
        {
            _sidePanelController = sidePanelController;
            _progressionManager = progressionManager;
            fieldController.FieldChanged += OnFieldChanged;
        }

        private void OnFieldChanged(GameSave save)
        {
            _sidePanelController.Update(save);
            _progressionManager.SetLevel(save);
        }
    }
}