public sealed class ClassificationFacade : BaseFacade<IClassificationComponent>, IClassificationFacade
{
    private ClassificationFacade(IClassificationComponent item) : base(item) { }
    public Classification Classification => Item.Classification;
    public bool IsClassification(Classification Classification) => Item.IsClassification(Classification);
    public static IClassificationFacade Get(Classification classification) 
        => new ClassificationFacade(ClassificationComponent.Get(classification));
}