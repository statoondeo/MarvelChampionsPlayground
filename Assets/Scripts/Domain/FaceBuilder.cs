using UnityEngine;

public sealed class FaceBuilder
{
    private readonly Sprite Sprite;
    private readonly string Title;
    private ICardType CardTypeComponent;
    private IClassification ClassificationComponent;

    public FaceBuilder(string title, Sprite sprite)
    {
        Sprite = sprite;
        Title = title;
    }
    public FaceBuilder WithCardType(ICardType cardType)
    {
        CardTypeComponent = cardType;
        return this;
    }
    public FaceBuilder WithClassification(IClassification classification)
    {
        ClassificationComponent = classification;
        return this;
    }
    public IFace Build() => new BasicFace(Title, Sprite, CardTypeComponent, ClassificationComponent);
}