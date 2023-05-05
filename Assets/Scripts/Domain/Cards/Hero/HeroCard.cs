public sealed class HeroCard : BaseCard, IHeroCard
{
    private HeroCard(
            IGame game,
            ICardMediator mediator,
            ICoreCardFacade coreCardFacade,
            IFlipFacade flipFacade,
            ITapFacade tapFacade,
            ILifeFacade lifeFacade,
            ILocationFacade locationFacade)
        : base(
            game,
            mediator,
            coreCardFacade,
            flipFacade,
            tapFacade,
            locationFacade)
    {
        LifeItem = lifeFacade;
        LifeItem.SetCard(this);
    }

    #region ILifeFacade

    private readonly ILifeFacade LifeItem;
    public void AddDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.RemoveDecorator(decorator);
    public int CurrentLife => LifeItem.CurrentLife;
    public int TotalLife => LifeItem.TotalLife;
    public int Damage => LifeItem.Damage;
    public void TakeDamage(int damage) => LifeItem.TakeDamage(damage);

    #endregion

    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
    {
        return new HeroCard(
                    game,
                    CardMediator.Get(),
                    CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                    FlipFacade.Get(
                        AlterEgoFace.Get((AlterEgoFaceModel)cardModel.Face),
                        HeroFace.Get((HeroFaceModel)cardModel.Back)),
                    TapFacade.Get(),
                    LifeFacade.Get(((HeroCardModel)cardModel).Life),
                    LocationFacade.Get(string.Empty));
    }
}
