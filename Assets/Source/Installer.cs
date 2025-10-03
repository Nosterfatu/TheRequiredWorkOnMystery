using System;
using UnityEngine;

namespace Source
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] HomeScreen _homeScreen;
        [SerializeField] AudioManager _audioManager;

        private void Awake()
        {
            var metaContext = new MetaContext();
            var loader = new Loader(metaContext);
            _homeScreen.Install(metaContext, loader,_audioManager);
        }
    }
}