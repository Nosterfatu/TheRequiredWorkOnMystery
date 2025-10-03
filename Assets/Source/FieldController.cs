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

        private Vector2Int? selected;

        public FieldController(GameField field, FieldView fieldView, GameSave gameSave)
        {
            _field = field;
            _fieldView = fieldView;
            _gameSave = gameSave;
            _fieldView.OnClick += OnClick;
            field.Load(gameSave);
            _field.AttachView(fieldView);
        }

        private void OnClick(Vector2Int index)
        {
            if (selected == null)
            {
                selected = index;
                return;
            }

            if (selected == index)
            {
                _fieldView.Hide(selected.Value);
                selected = null;
                return;
            }
            if (_field.TryMatch(selected.Value, index))
            {
                _fieldView.Clear(selected.Value);
                _fieldView.Clear(index);
                _gameSave.Score++;
                _gameSave.Progression = _field.GetSave();
            }
            else
            {
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