public interface ICardMediator : IMediator<ComponentType, ICard> {
    public void SetCard(ICard card);
}