using System;

public sealed class HeroFace : CoreFacade, IHeroFace
{
    #region IThwartFacade

    private readonly IThwartFacade ThwartItem;
    public int Thwart => ThwartItem.Thwart;
    public void AddDecorator(IDecorator<IThwartComponent> decorator) => ThwartItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IThwartComponent> decorator) => ThwartItem.RemoveDecorator(decorator);

    public void Register(Action<IThwartComponent> callback) => ThwartItem.Register(callback);
    public void UnRegister(Action<IThwartComponent> callback) => ThwartItem.UnRegister(callback);
    public void Notify(IThwartComponent data) => ThwartItem.Notify(data);

    #endregion

    #region IAttackFacade

    private readonly IAttackFacade AttackItem;
    public int Attack => AttackItem.Attack;
    public void AddDecorator(IDecorator<IAttackComponent> decorator) => AttackItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IAttackComponent> decorator) => AttackItem.RemoveDecorator(decorator);

    public void Register(Action<IAttackComponent> callback) => AttackItem.Register(callback);
    public void UnRegister(Action<IAttackComponent> callback) => AttackItem.UnRegister(callback);
    public void Notify(IAttackComponent data) => AttackItem.Notify(data);

    #endregion

    #region IDefenseFacade

    private readonly IDefenseFacade DefenseItem;
    public int Defense => DefenseItem.Defense;
    public void Register(Action<IDefenseComponent> callback) => DefenseItem.Register(callback);
    public void UnRegister(Action<IDefenseComponent> callback) => DefenseItem.UnRegister(callback);
    public void Notify(IDefenseComponent data) => DefenseItem.Notify(data);

    public void AddDecorator(IDecorator<IDefenseComponent> decorator) => DefenseItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IDefenseComponent> decorator) => DefenseItem.RemoveDecorator(decorator);

    #endregion

    #region IHandSizeFacade

    private readonly IHandSizeFacade HandSizeItem;
    public int HandSize => HandSizeItem.HandSize;
    public void AddDecorator(IDecorator<IHandSizeComponent> decorator)
        => HandSizeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IHandSizeComponent> decorator)
        => HandSizeItem.RemoveDecorator(decorator);

    public void Register(Action<IHandSizeComponent> callback) => HandSizeItem.Register(callback);
    public void UnRegister(Action<IHandSizeComponent> callback) => HandSizeItem.UnRegister(callback);
    public void Notify(IHandSizeComponent data) => HandSizeItem.Notify(data);

    #endregion

    #region Constructeur

    private HeroFace(
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IThwartFacade thwartFacade,
            IAttackFacade attackFacade,
            IDefenseFacade defenseFacade,
            IHandSizeFacade handSizeFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        HandSizeItem = handSizeFacade;
        ThwartItem = thwartFacade;
        AttackItem = attackFacade;
        DefenseItem = defenseFacade;
    }

    #endregion

    #region Factory

    public static IHeroFace Get(HeroFaceModel faceModel)
        => new HeroFace(
                    TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
                    CardTypeFacade.Get(faceModel.CardType),
                    ClassificationFacade.Get(faceModel.Classification),
                    ThwartFacade.Get(faceModel.Thwart),
                    AttackFacade.Get(faceModel.Attack),
                    DefenseFacade.Get(faceModel.Defense),
                    HandSizeFacade.Get(faceModel.HandSize));

    #endregion
}
