public sealed class HeroCard : BaseCard, IHeroCard
{
    private HeroCard(
            IGame game,
            IMediator<IComponent> faceMediator,
            IMediator<IComponent> backMediator,
            IResetFacade resetFacade,
            ICoreCardFacade coreCardFacade,
            IFlipFacade flipFacade,
            ITapFacade tapFacade,
            ILifeFacade lifeFacade,
            ILocationFacade locationFacade)
        : base(
            game,
            faceMediator,
            backMediator,
            coreCardFacade,
            flipFacade,
            tapFacade,
            locationFacade)
    {
        faceMediator.Register<ILifeComponent>(lifeFacade);
        faceMediator.Register<IResetComponent>(resetFacade);

        backMediator.Register<ILifeComponent>(faceMediator.GetEventHandler<ILifeComponent>());
        backMediator.Register<IResetComponent>(faceMediator.GetEventHandler<IResetComponent>());

        LifeItem = lifeFacade;
        LifeItem.SetCard(this);
        resetFacade.SetCard(this);
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

    #region Factory

    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
    {
        IMediator<IComponent> alterEgoMediator = ComponentMediator.Get();
        IMediator<IComponent> heroMediator = ComponentMediator.Get();
        return new HeroCard(
                    game,
                    alterEgoMediator,
                    heroMediator,
                    ResetFacade.Get(PermanentResetComponent.Get()),
                    CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                    FlipFacade.Get(
                        AlterEgoFace.Get(alterEgoMediator, (AlterEgoFaceModel)cardModel.Face),
                        HeroFace.Get(heroMediator, (HeroFaceModel)cardModel.Back)),
                    TapFacade.Get(),
                    LifeFacade.Get(((HeroCardModel)cardModel).Life),
                    LocationFacade.Get(string.Empty));
    }

    #endregion
}
