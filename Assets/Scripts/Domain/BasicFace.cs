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
    public bool IsOneOfCardType(CardType cardType1, CardType cardType2)
        => CardTypeComponent.IsOneOfCardType(cardType1, cardType2);
    public bool IsOneOfCardType(CardType cardType1, CardType cardType2, CardType cardType3)
        => CardTypeComponent.IsOneOfCardType(cardType1, cardType2, cardType3);
    public bool IsOneOfCardType(CardType cardType1, CardType cardType2, CardType cardType3, CardType cardType4)
        => CardTypeComponent.IsOneOfCardType(cardType1, cardType2, cardType3, cardType4);

    #endregion

    #region IClassification

    private readonly IClassification ClassificationComponent;
    public Classification Classification => ClassificationComponent.Classification;
    public bool IsClassification(Classification classification) => ClassificationComponent.IsClassification(classification);

    #endregion
}
