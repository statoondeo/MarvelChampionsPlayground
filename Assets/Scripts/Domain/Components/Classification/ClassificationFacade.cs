using System;

public sealed class ClassificationFacade : IClassificationFacade
{
    private readonly IFacade<IClassificationComponent> Facade;
    private ClassificationFacade(IClassificationComponent item) => Facade = FacadeComponent<IClassificationComponent>.Get(item);

    #region IFacade<IClassification>

    public IClassificationComponent Item { get; private set; }
    public void AddDecorator(IDecorator<IClassificationComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IClassificationComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IClassification

    public Action<IClassificationComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public Classification Classification => Item.Classification;
    public bool IsClassification(Classification Classification) => Item.IsClassification(Classification);

    #endregion

    public static IClassificationFacade Get(Classification classification) 
        => new ClassificationFacade(ClassificationComponent.Get(classification));
}