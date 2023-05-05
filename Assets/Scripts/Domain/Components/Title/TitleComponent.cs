using UnityEngine;

public sealed class TitleComponent : BaseComponent<ITitleComponent>, ITitleComponent
{
    private TitleComponent(string title, string subTitle, Sprite sprite)
        : base()
    {
        Type = ComponentType.Title;
        Title = title;
        SubTitle = subTitle;
        Sprite = sprite;
    }
    public string Title { get; private set; }
    public string SubTitle { get; private set; }
    public Sprite Sprite { get; private set; }
    public static ITitleComponent Get(string title, string subTitle, Sprite sprite) 
        => new TitleComponent(title, subTitle, sprite);
}
