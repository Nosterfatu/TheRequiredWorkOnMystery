using System;
using UnityEngine;

namespace Source
{
    public class GameInstaller: MonoBehaviour
    {
        [SerializeField] SidePanelView _sidePanelView;
        private void Awake()
        {
            var metaContext = new MetaContext();
            var loader = new Loader(metaContext);
            var sidePanel = new SidePanelController(_sidePanelView, metaContext, loader);
            
        }
    }
}