public sealed class DeckZone : BaseZone, IDeckZone
{
    private DeckZone(
            IGame game,
            IMediator<IZoneComponent> mediator,
            ICoreZoneComponentFacade coreZoneFacade,
            IShuffleComponentFacade shuffleFacade)
        : base(game, mediator, coreZoneFacade) 
    {
        ShuffleItem = shuffleFacade;
        Mediator.Register<IShuffleComponent>(ShuffleItem);
        SetZone(this);
    }
    public override void Add(ICard card)
    {
        base.Add(card);
        card.UnTap();
        card.FlipTo(1);
    }
    public override void SetZone(IZone zone)
    {
        base.SetZone(zone);
        ShuffleItem.SetZone(this);
    }
    #region IShuffleFacade

    private readonly IShuffleComponentFacade ShuffleItem;
    public void Shuffle() => ShuffleItem.Shuffle();
    public void AddDecorator(IZoneComponentDecorator<IShuffleComponent> decorator) => ShuffleItem.AddDecorator(decorator);
    public void RemoveDecorator(IZoneComponentDecorator<IShuffleComponent> decorator) => ShuffleItem.RemoveDecorator(decorator);

    #endregion

    public static IDeckZone Get(IGame game, string id, string label, string ownerId)
        => new DeckZone(
            game,
            ZoneComponentMediator.Get(),
            CoreZoneComponentFacade.Get(
                id,
                label,
                ownerId,
                CardRepository.Get()),
            ShuffleComponentFacade.Get());
}
