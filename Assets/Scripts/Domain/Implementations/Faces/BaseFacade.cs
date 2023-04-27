using UnityEngine;

//public abstract class BaseFace : IFace
//{
//    #region ICardType

//    protected readonly ICardType CardTypeBrick;
//    public CardType CardType => CardTypeBrick.CardType;
//    public bool IsCardType(CardType cardType) => CardTypeBrick.IsCardType(cardType);

//    #endregion

//    #region IClassification

//    protected readonly IClassification ClassificationBrick;
//    public Classification Classification => ClassificationBrick.Classification;
//    public bool IsClassification(Classification classification) => ClassificationBrick.IsClassification(classification);

//    #endregion

//    #region ITitle

//    protected readonly ITitle TitleBrick;
//    public string Title => TitleBrick.Title;
//    public string SubTitle => TitleBrick.SubTitle;
//    public Sprite Sprite => TitleBrick.Sprite;

//    #endregion

//    #region Constructeur

//    protected BaseFace(ITitle titleComponent, ICardType cardTypeComponent, IClassification classificationComponent)
//    {
//        TitleBrick = titleComponent;
//        CardTypeBrick = cardTypeComponent;
//        ClassificationBrick = classificationComponent;
//    }

//    #endregion
//}
public abstract class BaseFacade : IFacade
{
    #region Constructeur

    protected BaseFacade(ITitleFacade titleFacade, ICardTypeFacade cardTypeFacade, IClassificationFacade classificationFacade)
    {
        TitleFacade = titleFacade;
        CardTypeFacade = cardTypeFacade;
        ClassificationFacade = classificationFacade;
    }

    #endregion

    #region ICardTypeFacade

    private readonly ICardTypeFacade CardTypeFacade;
    ICardType IFacade<ICardType>.Item => CardTypeFacade.Item;
    CardType ICardType.CardType => CardTypeFacade.CardType;
    bool ICardType.IsCardType(CardType cardType) => CardTypeFacade.IsCardType(cardType);
    void IFacade<ICardType>.AddDecorator(IDecorator<ICardType> decorator) => CardTypeFacade.AddDecorator(decorator);
    void IFacade<ICardType>.RemoveDecorator(IDecorator<ICardType> decorator) => CardTypeFacade.RemoveDecorator(decorator);

    #endregion

    #region IClassificationFacade

    private readonly IClassificationFacade ClassificationFacade;
    IClassification IFacade<IClassification>.Item => ClassificationFacade.Item;
    Classification IClassification.Classification => ClassificationFacade.Classification;
    bool IClassification.IsClassification(Classification classification) => ClassificationFacade.IsClassification(classification);
    void IFacade<IClassification>.AddDecorator(IDecorator<IClassification> decorator) => ClassificationFacade.AddDecorator(decorator);
    void IFacade<IClassification>.RemoveDecorator(IDecorator<IClassification> decorator) => ClassificationFacade.RemoveDecorator(decorator);

    #endregion

    #region ITitleFacade

    private readonly ITitleFacade TitleFacade;
    ITitle IFacade<ITitle>.Item => TitleFacade.Item;
    string ITitle.Title => TitleFacade.Title;
    string ITitle.SubTitle => TitleFacade.SubTitle;
    Sprite ITitle.Sprite => TitleFacade.Sprite;
    void IFacade<ITitle>.AddDecorator(IDecorator<ITitle> decorator) => TitleFacade.AddDecorator(decorator);
    void IFacade<ITitle>.RemoveDecorator(IDecorator<ITitle> decorator) => TitleFacade.RemoveDecorator(decorator);

    #endregion
}