using System;
using UnityEngine;

namespace Source
{
    public class FieldController
    {
        public event Action<GameSave> FieldChanged;
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
            if (_field.TryMatch(selected.Value, index))
            {
                _fieldView.Clear(selected.Value);
                _fieldView.Clear(index);
                _gameSave.Score++;
            }
            selected = null;
            _gameSave.TurnCount++;
            FieldChanged?.Invoke(_gameSave);
            
            if (string.IsNullOrWhiteSpace( _field.GetSave()))
            {
                Win();
            }
            else if (_gameSave. TurnCount == _gameSave.MaxTurns)
            {
                Loose();
            }
        }

        private void Loose()
        {
            
        }

        private void Win()
        {
            
        }
    }
}