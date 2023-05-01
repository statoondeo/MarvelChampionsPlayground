using UnityEngine;

public sealed class TitleFacade : BaseComponentFacade<ITitleComponent>, ITitleFacade
{
    private TitleFacade(ITitleComponent item) : base(item) { }

    #region ITitle

    public string Title => Item.Title;
    public string SubTitle => Item.SubTitle;
    public Sprite Sprite => Item.Sprite;

    #endregion

    public static ITitleFacade Get(string title, string subTitle, Sprite sprite) 
        => new TitleFacade(TitleComponent.Get(title, subTitle, sprite));
}