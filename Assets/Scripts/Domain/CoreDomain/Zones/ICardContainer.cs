public interface ICardContainer : IRepository<ICard>
{
    ICard GetLast();
    ICard GetAt(int index);
}
