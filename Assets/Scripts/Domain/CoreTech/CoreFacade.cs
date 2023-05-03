using System;

using UnityEngine;

public abstract class CoreFacade : ICoreFacade
{
    #region Constructeur

    protected CoreFacade(ITitleFacade titleFacade, ICardTypeFacade cardTypeFacade, IClassificationFacade classificationFacade)
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
    public void Register(Action<ICardTypeComponent> callback) => CardTypeFacade.Register(callback);
    public void UnRegister(Action<ICardTypeComponent> callback) => CardTypeFacade.UnRegister(callback);
    public void Notify(ICardTypeComponent data) => CardTypeFacade.Notify(data);

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
    public void Register(Action<IClassificationComponent> callback) => ClassificationFacade.Register(callback);
    public void UnRegister(Action<IClassificationComponent> callback) => ClassificationFacade.UnRegister(callback);
    public void Notify(IClassificationComponent data) => ClassificationFacade.Notify(data);

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
    public void Register(Action<ITitleComponent> callback) => TitleFacade.Register(callback);
    public void UnRegister(Action<ITitleComponent> callback) => TitleFacade.UnRegister(callback);
    public void Notify(ITitleComponent data) => TitleFacade.Notify(data);

    public string Title => TitleFacade.Title;
    public string SubTitle => TitleFacade.SubTitle;
    public Sprite Sprite => TitleFacade.Sprite;

    #endregion
}