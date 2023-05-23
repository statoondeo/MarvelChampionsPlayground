﻿using System.Collections.Generic;
using System.Linq;

public sealed class CreateVillainDeckCommand : BaseCommand
{
    private CreateVillainDeckCommand(IGame game) : base(game) { }
    public override void Execute()
    {
        List<ICommand> commands = new();
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
                .ForEach(card => commands.Add(MoveToCommand.Get(Game, card, villainDeck.Id)));
            });
        CompositeCommand.Get(commands.ToArray()).Execute();
    }
    public static ICommand Get(IGame game) => new CreateVillainDeckCommand(game);
}
