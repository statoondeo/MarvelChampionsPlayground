using System.Collections.Generic;

public sealed class DeckZone : BaseZone, IDeckZone
{
    private DeckZone(
            IGame game,
            IMediator<IZoneComponent> mediator,
            ICoreZoneComponentFacade coreZoneFacade,
            IStateBasedComponentFacade stateBasedComponentFacade,
            IShuffleComponentFacade shuffleFacade)
        : base(game, mediator, coreZoneFacade) 
    {
        ShuffleItem = shuffleFacade;
        StateBasedComponentFacadeItem = stateBasedComponentFacade;
        Mediator.Register<IShuffleComponent>(ShuffleItem);
        Mediator.Register<IStateBasedComponent>(StateBasedComponentFacadeItem);
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
        StateBasedComponentFacadeItem.SetZone(this);
    }

    #region IShuffleFacade

    private readonly IShuffleComponentFacade ShuffleItem;
    public void Shuffle() => ShuffleItem.Shuffle();
    public void AddDecorator(IZoneComponentDecorator<IShuffleComponent> decorator) => ShuffleItem.AddDecorator(decorator);
    public void RemoveDecorator(IZoneComponentDecorator<IShuffleComponent> decorator) => ShuffleItem.RemoveDecorator(decorator);

    #endregion

    #region IStateBasedComponentFacade

    private readonly IStateBasedComponentFacade StateBasedComponentFacadeItem;
    public IEnumerable<IStateBasedCommand> GetStateBasedCommands() => StateBasedComponentFacadeItem.GetStateBasedCommands();
    public void AddDecorator(IZoneComponentDecorator<IStateBasedComponent> decorator) => StateBasedComponentFacadeItem.AddDecorator(decorator);
    public void RemoveDecorator(IZoneComponentDecorator<IStateBasedComponent> decorator) => StateBasedComponentFacadeItem.RemoveDecorator(decorator);

    #endregion

    public static IDeckZone Get(IGame game, string id, string label, string ownerId, HeroType heroType)
        => new DeckZone(
            game,
            ZoneComponentMediator.Get(),
            CoreZoneComponentFacade.Get(
                id,
                label,
                ownerId,
                CardRepository.Get()),
            StateBasedComponentFacade.Get(
                heroType.Equals(HeroType.Hero) 
                    ? EmptyPlayerDeckStateBasedCommand.Get(game, ownerId) 
                    : EmptyVillainDeckStateBasedCommand.Get(game, ownerId)),
            ShuffleComponentFacade.Get());
}
