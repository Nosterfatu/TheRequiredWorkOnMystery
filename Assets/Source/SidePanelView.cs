using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class SidePanelView : MonoBehaviour
    {
        public event Action HomeClicked;
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _maxTurnsText;
        [SerializeField] private TextMeshProUGUI _turnText;

        private void Start()
        {
            _button.onClick.AddListener(HomeClick);
        }

        private void HomeClick()
        {
            HomeClicked?.Invoke();
        }

        public void SetScore(int score)
        {
            _scoreText.text = $"Score: {score}";
        }

        public void SetMaxTurns(int maxTurns)
        {
            _maxTurnsText.text = $"Max turns: {maxTurns}";
        }

        public void SetTurn(int turn)
        {
            _turnText.text = $"Turn: {turn}";
        }
    }
}