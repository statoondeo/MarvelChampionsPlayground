public sealed class ClassificationComponent : IClassification
{
    public Classification Classification { get; private set; }
    public ClassificationComponent(Classification classification) => Classification = classification;
    public bool IsClassification(Classification classification) => Classification == classification;
}