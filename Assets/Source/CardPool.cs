using System.Collections.Generic;
using UnityEngine;

namespace Source
{
    public class CardPool : MonoBehaviour, ICardPool
    {
        private Queue<CardView> _cards = new Queue<CardView>();

        // Possibility to create view in Other container to prepare for some apearing on deck animation
        [SerializeField] private RectTransform _container;
        [SerializeField] private CardView _prefab;

        public CardView Get(string id)
        {
            var card = _cards.Count > 1 ? _cards.Dequeue() : Instantiate(_prefab, _container);
            card.Activate();
            card.SetView(id);
            return card;
        }

        public void Return(CardView view)
        {
            view.DisableInput();
            view.PlayDispose( () => _cards.Enqueue(view));
        }
    }
}