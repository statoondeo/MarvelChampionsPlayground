public sealed class ClassificationComponent : IClassification
{
    public Classification Classification { get; private set; }
    private ClassificationComponent(Classification classification) => Classification = classification;
    public bool IsClassification(Classification classification) => Classification == classification;
    public static IClassification Get(Classification classification) => new ClassificationComponent(classification);
}
public interface IClassificationFacade : IFacade<IClassification>, IClassification { }
public sealed class ClassificationFacade : IClassificationFacade
{
    private readonly IFacade<IClassification> Facade;
    private ClassificationFacade(IClassification item) => Facade = FacadeComponent<IClassification>.Get(item);

    #region IFacade<IClassification>

    public IClassification Item { get; private set; }
    public void AddDecorator(IDecorator<IClassification> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IClassification> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IClassification

    public Classification Classification => Item.Classification;
    public bool IsClassification(Classification Classification) => Item.IsClassification(Classification);

    #endregion

    public static IClassificationFacade Get(Classification classification) 
        => new ClassificationFacade(ClassificationComponent.Get(classification));
}