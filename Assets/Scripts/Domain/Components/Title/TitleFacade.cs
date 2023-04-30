using System;

using UnityEngine;

public sealed class TitleFacade : ITitleFacade
{
    private readonly IFacade<ITitleComponent> Facade;
    private TitleFacade(ITitleComponent item) => Facade = FacadeComponent<ITitleComponent>.Get(item);

    #region IFacade<ITitle>

    public ITitleComponent Item { get; private set; }
    public void AddDecorator(IDecorator<ITitleComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITitleComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ITitle

    public Action<ITitleComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public string Title => Item.Title;
    public string SubTitle => Item.SubTitle;
    public Sprite Sprite => Item.Sprite;

    #endregion

    public static ITitleFacade Get(string title, string subTitle, Sprite sprite) 
        => new TitleFacade(TitleComponent.Get(title, subTitle, sprite));
}