using System;
using UnityEngine;

namespace Source
{
    public class FieldController
    {
        public event Action<GameSave> FieldChanged;
        public event Action Won;
        public event Action Lost;
        private readonly GameField _field;
        private readonly FieldView _fieldView;
        private readonly GameSave _gameSave;
        private readonly AudioManager _audioManager;

        private Vector2Int? selected;

        public FieldController(GameField field, FieldView fieldView, GameSave gameSave, AudioManager audioManager)
        {
            _field = field;
            _fieldView = fieldView;
            _gameSave = gameSave;
            _audioManager = audioManager;
            _fieldView.OnClick += OnClick;
            field.Load(gameSave);
            _field.AttachView(fieldView);
        }

        private void OnClick(Vector2Int index)
        {
            if (selected == index)
            {
                _audioManager.PlaySound(SFX.CardHide, 1.5f);
                _fieldView.Hide(selected.Value);
                selected = null;
                return;
            }
            
            _audioManager.PlaySound(SFX.CardDrow);

            if (selected == null)
            {
                selected = index;
                return;
            }

  
            if (_field.TryMatch(selected.Value, index))
            {
                _audioManager.PlaySound(SFX.CardClear, 1.8f);

                _fieldView.Clear(selected.Value);
                _fieldView.Clear(index);
                _gameSave.Score++;
                _gameSave.Progression = _field.GetSave();
            }
            else
            {
                _audioManager.PlaySound(SFX.CardHide, 1.5f);
                _fieldView.Hide(selected.Value);
                _fieldView.Hide(index);
            }
            selected = null;
            _gameSave.TurnCount++;
            FieldChanged?.Invoke(_gameSave);
            
            if (string.IsNullOrWhiteSpace(_gameSave.Progression.Replace(" ", "").Replace("|", "").Replace("\n", "")))
            {
                Win();
            }
            else if (_gameSave. TurnCount >= _gameSave.MaxTurns)
            {
                Loose();
            }
        }

        private void Loose()
        {
            Lost?.Invoke();
        }

        private void Win()
        {
            Won?.Invoke();
        }
    }
}