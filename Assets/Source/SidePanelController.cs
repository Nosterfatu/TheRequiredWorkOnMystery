namespace Source
{
    public class SidePanelController
    {
        private readonly SidePanelView _sidePanelView;
        private readonly ILoader _loader;
        private readonly AudioManager _audioManager;

        public SidePanelController(SidePanelView sidePanelView, MetaContext metaContext, ILoader loader,
            AudioManager audioManager)
        {
            _sidePanelView = sidePanelView;
            _loader = loader;
            _audioManager = audioManager;

            _sidePanelView.HomeClicked += OnHomeClicked;
            _sidePanelView.SetMaxTurns(metaContext.Save.MaxTurns);
            Update(metaContext.Save);
        }

        private void OnHomeClicked()
        {
            _audioManager.PlaySound(SFX.ButtonClick);
            _loader.Unload();
        }

        public void Update(GameSave save)
        {
            _sidePanelView.SetScore(save.Score);
            _sidePanelView.SetTurn(save.TurnCount);
        }
    }
}