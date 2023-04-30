using System;

using UnityEngine;

public abstract class BaseFacade : ICoreFacade
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
    ICardTypeComponent IFacade<ICardTypeComponent>.Item => CardTypeFacade.Item;

    void IFacade<ICardTypeComponent>.AddDecorator(IDecorator<ICardTypeComponent> decorator) 
        => CardTypeFacade.AddDecorator(decorator);
    void IFacade<ICardTypeComponent>.RemoveDecorator(IDecorator<ICardTypeComponent> decorator) 
        => CardTypeFacade.RemoveDecorator(decorator);
    Action<ICardTypeComponent> IComponent<ICardTypeComponent>.OnChanged
    { get => CardTypeFacade.OnChanged; set => CardTypeFacade.OnChanged = value; }

    #endregion

    #region IClassificationFacade

    private readonly IClassificationFacade ClassificationFacade;
    IClassificationComponent IFacade<IClassificationComponent>.Item => ClassificationFacade.Item;

    void IFacade<IClassificationComponent>.AddDecorator(IDecorator<IClassificationComponent> decorator) 
        => ClassificationFacade.AddDecorator(decorator);
    void IFacade<IClassificationComponent>.RemoveDecorator(IDecorator<IClassificationComponent> decorator) 
        => ClassificationFacade.RemoveDecorator(decorator);
    Action<IClassificationComponent> IComponent<IClassificationComponent>.OnChanged
    { get => ClassificationFacade.OnChanged; set => ClassificationFacade.OnChanged = value; }

    #endregion

    #region ITitleFacade

    private readonly ITitleFacade TitleFacade;
    ITitleComponent IFacade<ITitleComponent>.Item => TitleFacade.Item;
    string ITitleComponent.Title => TitleFacade.Title;
    string ITitleComponent.SubTitle => TitleFacade.SubTitle;
    Sprite ITitleComponent.Sprite => TitleFacade.Sprite;
    void IFacade<ITitleComponent>.AddDecorator(IDecorator<ITitleComponent> decorator) 
        => TitleFacade.AddDecorator(decorator);
    void IFacade<ITitleComponent>.RemoveDecorator(IDecorator<ITitleComponent> decorator) 
        => TitleFacade.RemoveDecorator(decorator);

    bool ICardType.IsCardType(CardType cardType)
        => CardTypeFacade.IsCardType(cardType);

    bool IClassification.IsClassification(Classification classification)
        => ClassificationFacade.IsClassification(classification);

    Action<ITitleComponent> IComponent<ITitleComponent>.OnChanged
    { get => TitleFacade.OnChanged; set => TitleFacade.OnChanged = value; }

    CardType ICardType.CardType => CardTypeFacade.CardType;

    Classification IClassification.Classification => ClassificationFacade.Classification;

    #endregion
}