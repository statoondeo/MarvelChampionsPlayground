public sealed class ClassificationSelector : ISelector<ICard>
{
    private readonly Classification Item;
    private ClassificationSelector(Classification item) => Item = item;
    public bool Match(ICard card) => card.IsClassification(Item);
    public static ISelector<ICard> Get(Classification item) => new ClassificationSelector(item);
}
