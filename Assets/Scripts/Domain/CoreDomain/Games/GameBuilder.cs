using System;

public sealed class GameBuilder
{

    private const string BATTLEFIELD = "BATTLEFIELD";
    private const string DECK = "DECK";

    private readonly IGame Game;
    private readonly IZone Battlefield;
    private readonly ZoneFactory ZoneFactory;

    public GameBuilder(IPicker<ICard> anyCardPicker)
    {
        Game = new Game(
            //GameMediator.Get(),
            ZoneRepository.Get(),
            CardRepository.Get(),
            PlayerRepository.Get(),
            anyCardPicker);
        Game.RegisterSetupCommand(GameSetupCommand.Get(Game));
        ZoneFactory = new();
        Battlefield = ZoneFactory.Create(Game, BATTLEFIELD, null);
        Game.Add(Battlefield);
    }
    public GameBuilder WithRoutineController(RoutineController routineController)
    {
        Game.RoutineController = routineController;
        return this;
    }
    public GameBuilder WithPlayer(DeckModel deckModel)
    {

        // Création du joueur
        IActor player = deckModel.HeroType.Equals(HeroType.Hero)
                        ? PlayerActor.Get(Game, deckModel.Id, deckModel.name, deckModel.HeroType)
                        : VillainActor.Get(Game, deckModel.Id, deckModel.name, deckModel.HeroType);
        Game.Add(player);

        // Création des zones du joueur
        player.RegisterZoneId(BATTLEFIELD, Battlefield.Id);
        foreach (string zoneName in deckModel.SetupModel.Zones)
        {
            if (BATTLEFIELD.Equals(zoneName)) continue;
            IZone zone = ZoneFactory.Create(Game, zoneName, player.Id);
            player.RegisterZoneId(zoneName, zone.Id);
            Game.Add(zone);
        }

        // Création des cartes du joueur
        CardFactory cardFactory = new();
        foreach (CardModel cardModel in deckModel)
        {
            ICard card = cardFactory.Create(Game, Guid.NewGuid().ToString(), player.Id, cardModel); 
            Game.Add(card);
            card.MoveTo("DECK");
            if (card.IsCardType(CardType.Hero)) player.SetHeroCard(card as IHeroCard);
        }

        return this;
    }
    public IGame Build() => Game;
}