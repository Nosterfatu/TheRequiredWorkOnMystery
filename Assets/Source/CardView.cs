using System;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    internal class CardView : MonoBehaviour
    {
        [SerializeField] Button _button;
        public event Action<Vector2Int> OnClick;
        
        private Vector2Int _index;
        public void SetIndex(Vector2Int index)
        {
            _index = index;
        }

        private void Start()
        {
            _button.onClick.AddListener(Click);
        }

        private void Click()
        {
            OnClick?.Invoke(_index);
        }
    }
}