namespace Source
{
    internal interface ICardPool
    {
        CardView Get(string id);
        void Return(CardView view);
    }
}