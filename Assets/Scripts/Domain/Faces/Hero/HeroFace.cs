using System;

public sealed class HeroFace : BaseFacade, IHeroFace
{
    #region IThwartFacade

    private readonly IThwartFacade ThwartItem;
    IThwartComponent IFacade<IThwartComponent>.Item => ThwartItem.Item;
    int IThwartComponent.Thwart => ThwartItem.Thwart;
    Action<IThwartComponent> IComponent<IThwartComponent>.OnChanged
    { get => ThwartItem.OnChanged; set => ThwartItem.OnChanged = value; }
    void IFacade<IThwartComponent>.AddDecorator(IDecorator<IThwartComponent> decorator) => ThwartItem.AddDecorator(decorator);
    void IFacade<IThwartComponent>.RemoveDecorator(IDecorator<IThwartComponent> decorator) => ThwartItem.RemoveDecorator(decorator);

    #endregion

    #region IAttackFacade

    private readonly IAttackFacade AttackItem;
    IAttackComponent IFacade<IAttackComponent>.Item => AttackItem.Item;
    int IAttackComponent.Attack => AttackItem.Attack;
    Action<IAttackComponent> IComponent<IAttackComponent>.OnChanged
    { get => AttackItem.OnChanged; set => AttackItem.OnChanged = value; }
    void IFacade<IAttackComponent>.AddDecorator(IDecorator<IAttackComponent> decorator) => AttackItem.AddDecorator(decorator);
    void IFacade<IAttackComponent>.RemoveDecorator(IDecorator<IAttackComponent> decorator) => AttackItem.RemoveDecorator(decorator);

    #endregion

    #region IDefenseFacade

    private readonly IDefenseFacade DefenseItem;
    IDefenseComponent IFacade<IDefenseComponent>.Item => DefenseItem.Item;
    int IDefenseComponent.Defense => DefenseItem.Defense;
    Action<IDefenseComponent> IComponent<IDefenseComponent>.OnChanged
    { get => DefenseItem.OnChanged; set => DefenseItem.OnChanged = value; }

    void IFacade<IDefenseComponent>.AddDecorator(IDecorator<IDefenseComponent> decorator) => DefenseItem.AddDecorator(decorator);
    void IFacade<IDefenseComponent>.RemoveDecorator(IDecorator<IDefenseComponent> decorator) => DefenseItem.RemoveDecorator(decorator);

    #endregion

    #region IHandSizeFacade

    private readonly IHandSizeFacade HandSizeItem;
    IHandSizeComponent IFacade<IHandSizeComponent>.Item => HandSizeItem.Item;
    int IHandSizeComponent.HandSize => HandSizeItem.HandSize;

    Action<IHandSizeComponent> IComponent<IHandSizeComponent>.OnChanged 
    { get => HandSizeItem.OnChanged; set => HandSizeItem.OnChanged = value; }

    void IFacade<IHandSizeComponent>.AddDecorator(IDecorator<IHandSizeComponent> decorator) => HandSizeItem.AddDecorator(decorator);
    void IFacade<IHandSizeComponent>.RemoveDecorator(IDecorator<IHandSizeComponent> decorator) => HandSizeItem.RemoveDecorator(decorator);

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
