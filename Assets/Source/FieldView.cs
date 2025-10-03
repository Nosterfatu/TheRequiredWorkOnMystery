using System;
using UnityEngine;

namespace Source
{
    public class FieldView : MonoBehaviour
    {
        [SerializeField] RectTransform _container;
        [SerializeField] float _spacing;
        
        private int _height;
        private int _width;
        private CardView[][] _cards;

        private ICardPool _cardPool;
        public event Action<Vector2Int> OnClick;

        public void Install(ICardPool cardPool)
        {
            _cardPool = cardPool;
        }

        public void Setup(string[][] field)
        {
            _height = field.Length;
            // always have the same width for all lines 
            _width = field[0].Length;
            
            _cards = new CardView[_height][];
            var size = new Vector2((_container.sizeDelta.x - (_spacing * _width - 1)) / _width ,
                (_container.sizeDelta.y - (_spacing * _height - 1)) / _height);
            for (var y = 0; y < _height; y++)
            {
                _cards[y] = new CardView[_width];
                for (int x = 0; x < _width; x++)
                {
                    if (field[y][x] == " ")
                        continue;
                    
                    var card = _cardPool.Get(field[y][x]);
                    card.OnClick += CardOnOnClick;
                    card.transform.SetParent(_container);
                    card.SetIndex(new Vector2Int(x,y));
                    var rectTr = card.transform as RectTransform;
                    rectTr.pivot = rectTr.anchorMin = rectTr.anchorMax = Vector2.up;
                    rectTr.sizeDelta = size;
                    rectTr.anchoredPosition = new Vector2((size.x +_spacing)* x, (size.y +_spacing)* -y);
                    _cards[y][x] = card;
                }
            }
        }

        public void Clear(Vector2Int position)
        {
            var card = _cards[position.y][position.x];
            if (card != null)
            {
                card.OnClick -= CardOnOnClick;
                _cardPool.Return(card);
            }
            
        }

        private void CardOnOnClick(Vector2Int index)
        {
            OnClick?.Invoke(index);
        }
    }
}