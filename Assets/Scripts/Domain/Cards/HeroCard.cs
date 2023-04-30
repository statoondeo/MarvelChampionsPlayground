using System;

public sealed class HeroCard : BaseCard, IHeroCard
{
    public HeroCard(ICoreCardFacade coreCardFacade, IFlipFacade flipFacade, ITapFacade tapFacade, ILifeFacade lifeFacade)
        : base(coreCardFacade, flipFacade, tapFacade)
        => LifeItem = lifeFacade;

    #region ILifeFacade

    private readonly ILifeFacade LifeItem;
    ILifeComponent IFacade<ILifeComponent>.Item => LifeItem.Item;
    int ILifeComponent.Life => LifeItem.Life;
    void IFacade<ILifeComponent>.AddDecorator(IDecorator<ILifeComponent> decorator) 
        => LifeItem.AddDecorator(decorator);
    void IFacade<ILifeComponent>.RemoveDecorator(IDecorator<ILifeComponent> decorator) 
        => LifeItem.RemoveDecorator(decorator);
    Action<ILifeComponent> IComponent<ILifeComponent>.OnChanged
    { get => LifeItem.OnChanged; set => LifeItem.OnChanged = value; }

    #endregion

    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
        => new HeroCard(
            CoreCardFacade.Get(cardModel.CardId, id, ownerId, game),
            FlipFacade.Get(
                AlterEgoFace.Get((AlterEgoFaceModel)cardModel.Face),
                HeroFace.Get((HeroFaceModel)cardModel.Back)),
            TapFacade.Get(),
            LifeFacade.Get(((HeroCardModel)cardModel).Life));
}
