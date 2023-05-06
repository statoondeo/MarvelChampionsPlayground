using UnityEngine;

public abstract class BaseFace : IFace, ICoreFacade
{
    public ComponentType Type => ComponentType.Composite;

    #region ICardHolder

    public ICard Card { get; private set; }
    public virtual void SetCard(ICard card) 
    {
        Card = card;
        CardTypeFacade.SetCard(card);
        ClassificationFacade.SetCard(card);
        TitleFacade.SetCard(card);
    }

    #endregion

    #region Constructeur

    protected BaseFace(ITitleFacade titleFacade, ICardTypeFacade cardTypeFacade, IClassificationFacade classificationFacade)
    {
        TitleFacade = titleFacade;
        CardTypeFacade = cardTypeFacade;
        ClassificationFacade = classificationFacade;
    }

    #endregion

    #region ICardTypeFacade

    private readonly ICardTypeFacade CardTypeFacade;

    public void AddDecorator(IDecorator<ICardTypeComponent> decorator) 
        => CardTypeFacade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ICardTypeComponent> decorator) 
        => CardTypeFacade.RemoveDecorator(decorator);

    public CardType CardType => CardTypeFacade.CardType;
    public bool IsCardType(CardType cardType)
        => CardTypeFacade.IsCardType(cardType);

    #endregion

    #region IClassificationFacade

    private readonly IClassificationFacade ClassificationFacade;

    public void AddDecorator(IDecorator<IClassificationComponent> decorator)
        => ClassificationFacade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IClassificationComponent> decorator)
        => ClassificationFacade.RemoveDecorator(decorator);

    public Classification Classification => ClassificationFacade.Classification;
    public bool IsClassification(Classification classification)
        => ClassificationFacade.IsClassification(classification);

    #endregion

    #region ITitleFacade

    private readonly ITitleFacade TitleFacade;
    public void AddDecorator(IDecorator<ITitleComponent> decorator) 
        => TitleFacade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITitleComponent> decorator) 
        => TitleFacade.RemoveDecorator(decorator);

    public string Title => TitleFacade.Title;
    public string SubTitle => TitleFacade.SubTitle;
    public Sprite Sprite => TitleFacade.Sprite;

    #endregion
}