public sealed class CardIdControllerSelector : ISelector<BaseCardController>
{
    private readonly string CardId;
    private CardIdControllerSelector(string cardId) => CardId = cardId;
    public bool Match(BaseCardController item) => CardId.Equals(item.Id);
    public static ISelector<BaseCardController> Get(string cardId) => new CardIdControllerSelector(cardId);
}
