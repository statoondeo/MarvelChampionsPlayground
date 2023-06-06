using System;
using System.Collections.Generic;
using System.Linq;

public sealed class GameBuilder
{

    private const string BATTLEFIELD = "BATTLEFIELD";
    private const string STACK = "STACK";
    private const string DECK = "DECK";

    private readonly IPicker<ICard> CardPicker;
    private RoutineController RoutineController;
    private readonly List<DeckModel> Players;

    public GameBuilder(IPicker<ICard> cardPicker)
    {
        Players = new List<DeckModel>(4);
        CardPicker = cardPicker;
    }
    public GameBuilder WithRoutineController(RoutineController routineController)
    {
        RoutineController = routineController;
        return this;
    }
    public GameBuilder WithPlayer(DeckModel deckModel)
    {
        Players.Add(deckModel);
        return this;
    }
    public IGame Build()
    {
        IGame game = new Game(
            ZoneRepository.Get(),
            CardRepository.Get(),
            PlayerRepository.Get(),
            CardPicker);
        game.RegisterSetupCommand(GameSetupCommand.Get(game));
        ZoneFactory zoneFactory = new();
        IZone battlefieldZone = zoneFactory.Create(game, BATTLEFIELD, null);
        IZone stackZone = zoneFactory.Create(game, STACK, null);
        game.Add(battlefieldZone);
        game.Add(stackZone);

        game.RoutineController = RoutineController;

        // Création des joueurs
        Players.ForEach(player =>
        {
            IActor actor = player.HeroType.Equals(HeroType.Hero)
                            ? PlayerActor.Get(game, player.Id, player.name, player.HeroType)
                            : VillainActor.Get(game, player.Id, player.name, player.HeroType);
            game.Add(actor);
        });

        // Création des zones
        Players.ForEach(actor =>
        {
            IActor player = game.GetFirst(PlayerIdSelector.Get(actor.Id));
            player.RegisterZoneId(BATTLEFIELD, battlefieldZone.Id);
            player.RegisterZoneId(STACK, stackZone.Id);
            foreach (string zoneName in actor.SetupModel.Zones)
            {
                if (BATTLEFIELD.Equals(zoneName)) continue;
                if (STACK.Equals(zoneName)) continue;
                IZone zone = zoneFactory.Create(game, zoneName, player);
                player.RegisterZoneId(zoneName, zone.Id);
                if (zone is IStateBasedComponent deckZone)
                    deckZone.GetStateBasedCommands().ToList().ForEach(command => game.RegisterStateBasedCommand(command));
                game.Add(zone);
            }
        });

        // Création des cartes
        CardFactory cardFactory = new();
        Players.ForEach(actor =>
        {
            IActor player = game.GetFirst(PlayerIdSelector.Get(actor.Id));
            foreach (CardLocationModel cardLocationModel in actor.CardModels)
            {
                ICard card = cardFactory.Create(game, Guid.NewGuid().ToString(), player.Id, cardLocationModel.CardModel);
                game.Add(card);
                card.MoveTo(cardLocationModel.Location);
                card.SetOrder(cardLocationModel.Order);
                if (card.IsCardType(CardType.Hero)) player.SetHeroCard(card as IHeroCard);
            }
        });

        return game;
    }
}