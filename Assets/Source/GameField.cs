using UnityEngine;

namespace Source
{
    public class GameField
    {
        private string[][] _field;
        private FieldView _fieldView;

        public void Load(GameSave gameSave)
        {
            var lines = gameSave.Progression.Split('\n');
            _field = new string[lines.Length][];
            for (var index = 0; index < lines.Length; index++)
            {
                var line = lines[index];
                var symbols = line.Split("|");

                _field[index] = new string[symbols.Length];
                for (int i = 0; i < symbols.Length; i++)
                {
                    _field[index][i] = symbols[i];
                }
            }
        }

        public void AttachView(FieldView view)
        {
            view.Setup(_field);
        }

        public bool TryMatch(Vector2Int cell1, Vector2Int cell2)
        {
            var match = _field[cell1.y][cell1.x] == _field[cell2.y][cell2.x];

            if (match)
            {
                _field[cell1.y][cell1.x] = " ";
                _field[cell2.y][cell2.x] = " ";
            }

            return match;
        }

        public string GetSave()
        {
            string updatedLevel = "";
            for (var index = 0; index < _field.Length; index++)
            {
                var level = _field[index];
                updatedLevel =string.Concat(updatedLevel, string.Join("|", level), index == _field.Length - 1 ? "" : "\n");
            }
            return updatedLevel;
        }
    }
}