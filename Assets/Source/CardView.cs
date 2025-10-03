using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] Button _button;
        // Simplified, Emoji or sprite fonts could be used as view 
        // Could be replaced with image with texture injection
        [SerializeField] TextMeshProUGUI sign;
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

        public void SetView(string id)
        {
            sign.text = id;
        }

        public void Activate()
        {
            _button.enabled = true;
            gameObject.SetActive(true);
        }

        public void DisableInput()
        {
            _button.enabled = false;
        }

        public void PlayDispose(Action onFinish = null)
        {
            StartCoroutine(Dispose(onFinish));
        }

        IEnumerator Dispose(Action onFinish = null)
        {
            gameObject.SetActive(false);
            yield return new WaitForSeconds(2);
            onFinish?.Invoke();
        }
    }
}