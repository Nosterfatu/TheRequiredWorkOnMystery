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
            DisableInput();
            StartCoroutine(Fade());
        }

        IEnumerator Fade()
        {
            bool increase = sign.color.a < 1;
            float t = 0;
            while (t < 1.1f)
            {
                t += Time.deltaTime;
                var color = sign.color;
                color.a = increase ? t : 1 - t;
                color.a = Mathf.Clamp01(color.a);
                sign.color = color;
                yield return new WaitForEndOfFrame();
            }
            
            yield return new WaitForSeconds(0.2f);
            _button.enabled = true;
        }

        public void SetView(string id)
        {
            sign.text = id;
        }

        public void Activate()
        {
            _button.enabled = true;
            gameObject.SetActive(true);
            sign.color = new Color();
        }

        public void DisableInput()
        {
            _button.enabled = false;
        }

        public void PlayDispose(Action onFinish = null)
        {
            DisableInput();
            StartCoroutine(Dispose(onFinish));
        }

        IEnumerator Dispose(Action onFinish = null)
        {
            yield return new WaitForSeconds(2);
            onFinish?.Invoke();
            gameObject.SetActive(false);
        }

        IEnumerator HideWithTimer()
        {
            yield return new WaitForSeconds(1.5f);
            sign.color = new Color();
            _button.enabled = true;
        }

        public void Hide()
        {
            DisableInput();
            StartCoroutine(HideWithTimer());
        }
    }
}