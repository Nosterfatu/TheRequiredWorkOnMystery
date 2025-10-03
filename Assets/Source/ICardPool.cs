namespace Source
{
    public interface ICardPool
    {
        CardView Get(string id);
        void Return(CardView view);
    }
}