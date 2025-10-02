using UnityEngine;

namespace Source
{
    public class GameField
    {
        private string[][] _field;
        private FieldView _fieldView;
        private GameSave _save;


        public void Load(GameSave gameSave)
        {
            _save = gameSave;
            var lines = gameSave.Level.Split('\n');
            _field = new string[lines.Length][];
            for (var index = 0; index < lines.Length; index++)
            {
                var line = lines[index];
                var symbols = line.Split("|");

                _field[index] = new string[symbols.Length];
            }
        }

        public void AttachView(FieldView view)
        {
            view.Setup(_field);
        }

        public bool TryMatch((int, int) cell1, (int, int) cell2)
        {
            var match = _field[cell1.Item1][cell1.Item2] == _field[cell2.Item1][cell2.Item2];

            if (match)
            {
                _field[cell1.Item1][cell1.Item2] = " ";
                _field[cell2.Item1][cell2.Item2] = " ";
                UpdateSave();
            }

            return match;
        }

        private void UpdateSave()
        {
            string updatedLevel = "";
            for (var index = 0; index < _field.Length; index++)
            {
                var level = _field[index];
                string.Concat(updatedLevel, string.Join("|", level), index == _field.Length - 1 ? "\n" : "");
            }
        }
    }

    public class FieldView : MonoBehaviour
    {
        private int _height;
        private int _width;

        void Install(ICardPool cardPool)
        {
            
        }

        public void Setup(string[][] field)
        {
            _height = field.Length;
            // always have the same width for all lines 
            _width = field[0].Length;
        }
    }

    internal interface ICardPool
    {
        CardView Get(string id);
        void Return(CardView view);
    }
}