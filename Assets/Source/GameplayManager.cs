namespace Source
{
    public class GameplayManager
    {
        private readonly SidePanelController _sidePanelController;

        public GameplayManager(FieldController fieldController, SidePanelController sidePanelController)
        {
            _sidePanelController = sidePanelController;
            fieldController.FieldChanged+= OnFieldChanged;
        }

        private void OnFieldChanged(GameSave save)
        {
            _sidePanelController.Update(save);
        }
    }
}