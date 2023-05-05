using UnityEngine;

public sealed class TitleFacade : BaseFacade<ITitleComponent>, ITitleFacade
{
    private TitleFacade(ITitleComponent item) : base(item) { }
    public string Title => Item.Title;
    public string SubTitle => Item.SubTitle;
    public Sprite Sprite => Item.Sprite;
    public static ITitleFacade Get(string title, string subTitle, Sprite sprite) 
        => new TitleFacade(TitleComponent.Get(title, subTitle, sprite));
}