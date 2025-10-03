using System;
using UnityEngine;

namespace Source
{
    public class GameInstaller: MonoBehaviour
    {
        [SerializeField] SidePanelView _sidePanelView;
        [SerializeField] private FieldView _fieldView;
        [SerializeField] private CardPool _cardPool;
        [SerializeField] private AudioManager _audioManager;
        
        //preserve from GC as DI Container is not Implemented
        private GameplayManager _gameplayManager;

        private void Awake()
        {
            _fieldView.Install(_cardPool);
            var metaContext = new MetaContext();
            var loader = new Loader(metaContext);
            var sidePanel = new SidePanelController(_sidePanelView, metaContext, loader, _audioManager);
            var fieldController = new FieldController(new GameField(), _fieldView, metaContext.Save, _audioManager);
            _gameplayManager = new GameplayManager(fieldController,sidePanel, metaContext, loader, _audioManager);
            _audioManager.PlaySound(SFX.LevelStarted);
            
        }
    }
}