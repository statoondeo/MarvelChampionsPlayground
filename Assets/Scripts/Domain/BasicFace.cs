using UnityEngine;

public sealed class BasicFace : IFace
{
    public BasicFace(string faceTitle, Sprite facePath, ICardType cardTypeComponent, IClassification classificationComponent)
    {
        Sprite = facePath;
        Title = faceTitle;
        CardTypeComponent = cardTypeComponent;
        ClassificationComponent = classificationComponent;
    }

    public Sprite Sprite { get; private set; }
    public string Title { get; private set; }
    public string SubTitle { get; private set; }

    #region ICardType

    private readonly ICardType CardTypeComponent;
    public CardType CardType => CardTypeComponent.CardType;
    public bool IsCardType(CardType cardType) => CardTypeComponent.IsCardType(cardType);

    #endregion

    #region IClassification

    private readonly IClassification ClassificationComponent;
    public Classification Classification => ClassificationComponent.Classification;
    public bool IsClassification(Classification classification) => ClassificationComponent.IsClassification(classification);

    #endregion
}
