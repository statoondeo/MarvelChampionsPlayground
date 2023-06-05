public sealed class HeroCard : BaseCard, IHeroCard
{
    #region Constructor

    private HeroCard(
            IGame game,
            ICardTypeFacade cardTypeFacade,
            IMediator<ICardComponent> faceMediator,
            IMediator<ICardComponent> backMediator,
            ICoreCardFacade coreCardFacade,
            IFlipFacade flipFacade,
            ITapFacade tapFacade,
            ILifeFacade lifeFacade,
            IEnterPlayFacade enterPlayFacade,
            ILocationFacade locationFacade)
        : base(
            game,
            cardTypeFacade,
            faceMediator,
            backMediator,
            coreCardFacade,
            flipFacade,
            tapFacade,
            locationFacade)
    {
        faceMediator.Register<ILifeComponent>(lifeFacade);
        faceMediator.Register<IEnterPlayComponent>(enterPlayFacade);
        backMediator.Register<ILifeComponent>(faceMediator.GetEventHandler<ILifeComponent>());
        backMediator.Register<IEnterPlayComponent>(faceMediator.GetEventHandler<IEnterPlayComponent>());

        LifeItem = lifeFacade;
        EnterPlayItem = enterPlayFacade;
        SetCard(this);
    }

    #endregion

    #region ICardHolder

    private readonly IEnterPlayFacade EnterPlayItem;
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        LifeItem.SetCard(card);
        EnterPlayItem.SetCard(card);
    }

    #endregion

    #region ILifeFacade

    private readonly ILifeFacade LifeItem;
    public void AddDecorator(ICardComponentDecorator<ILifeComponent> decorator) => LifeItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<ILifeComponent> decorator) => LifeItem.RemoveDecorator(decorator);
    public int CurrentLife => LifeItem.CurrentLife;
    public int TotalLife => LifeItem.TotalLife;
    public int Damage => LifeItem.Damage;
    public void TakeDamage(int damage) => LifeItem.TakeDamage(damage);
    public void HealDamage(int damage) => LifeItem.HealDamage(damage);

    #endregion

    #region Factory

    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
    {
        ILifeFacade lifeFacade = LifeFacade.Get(((HeroCardModel)cardModel).Life);
        IMediator<ICardComponent> alterEgoMediator = CardComponentMediator.Get();
        IMediator<ICardComponent> heroMediator = CardComponentMediator.Get();
        return new HeroCard(
                    game,
                    CardTypeFacade.Get(CardType.Hero),
                    alterEgoMediator,
                    heroMediator,
                    CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                    FlipFacade.Get(
                        AlterEgoFace.Get(game, alterEgoMediator, lifeFacade, (AlterEgoFaceModel)cardModel.Face),
                        HeroFace.Get(heroMediator, lifeFacade, (HeroFaceModel)cardModel.Back)),
                    TapFacade.Get(),
                    lifeFacade,
                    EnterPlayFacade.Get(HeroEnterPlayComponent.Get()),
                    LocationFacade.Get(string.Empty));
    }

    #endregion
}
