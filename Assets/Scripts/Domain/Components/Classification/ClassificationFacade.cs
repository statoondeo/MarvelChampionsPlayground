public sealed class ClassificationFacade : BaseComponentFacade<IClassificationComponent>, IClassificationFacade
{
    private ClassificationFacade(IClassificationComponent item) : base(item) { }


    #region IClassification

    public Classification Classification => Item.Classification;
    public bool IsClassification(Classification Classification) => Item.IsClassification(Classification);

    #endregion

    public static IClassificationFacade Get(Classification classification) 
        => new ClassificationFacade(ClassificationComponent.Get(classification));
}