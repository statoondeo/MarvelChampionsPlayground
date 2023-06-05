using System.Collections;
using System.Linq;

public sealed class CreateVillainDeckCommand : BaseSingleCommand
{
    private CreateVillainDeckCommand(IGame game) : base(game) { }
    public override IEnumerator Execute()
    {
        IVillainActor villain = Game.GetFirst(PlayerTypeSelector.Get(HeroType.Villain)) as IVillainActor;
        IZone villainDeck = Game.GetFirst(ZoneNameSelector.Get(Game, villain.Id, "DECK"));
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(
            (item) =>
            {
                Game.GetAll(
                    AndCompositeSelector.Get(
                        LocationSelector.Get("EXIL"),
                        OwnerIdSelector.Get(item.Id),
                        CardTypeSelector.Get(CardType.Obligation))).ToList()
                .ForEach(card => Game.Enqueue(MoveToCommand.Get(Game, card, villainDeck.Id)));
            });
        yield return base.Execute();
    }
    public static ICommand Get(IGame game) => new CreateVillainDeckCommand(game);
}
