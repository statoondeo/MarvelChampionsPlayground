public sealed class ClassificationComponent : BaseComponent<IClassificationComponent>, IClassificationComponent
{
    public Classification Classification { get; private set; }
    private ClassificationComponent(Classification classification) : base() => Classification = classification;
    public bool IsClassification(Classification classification) => Classification == classification;
    public static IClassificationComponent Get(Classification classification) => new ClassificationComponent(classification);
}
