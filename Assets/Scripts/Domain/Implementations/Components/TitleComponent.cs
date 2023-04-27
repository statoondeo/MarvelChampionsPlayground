using UnityEngine;

public sealed class TitleComponent : ITitle
{
    private TitleComponent(string title, string subTitle, Sprite sprite)
    {
        Title = title;
        SubTitle = subTitle;
        Sprite = sprite;
    }
    public string Title { get; private set; }
    public string SubTitle { get; private set; }
    public Sprite Sprite { get; private set; }
    public static ITitle Get(string title, string subTitle, Sprite sprite) => new TitleComponent(title, subTitle, sprite);
}
public interface ITitleFacade : IFacade<ITitle>, ITitle { }
public sealed class TitleFacade : ITitleFacade
{
    private readonly IFacade<ITitle> Facade;
    private TitleFacade(ITitle item) => Facade = FacadeComponent<ITitle>.Get(item);

    #region IFacade<ITitle>

    public ITitle Item { get; private set; }
    public void AddDecorator(IDecorator<ITitle> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITitle> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ITitle

    public string Title => Item.Title;
    public string SubTitle => Item.SubTitle;
    public Sprite Sprite => Item.Sprite;

    #endregion

    public static ITitleFacade Get(string title, string subTitle, Sprite sprite) 
        => new TitleFacade(TitleComponent.Get(title, subTitle, sprite));
}