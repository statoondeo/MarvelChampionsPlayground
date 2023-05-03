using System;

public sealed class GameBuilder
{

    private const string BATTLEFIELD = "BATTLEFIELD";
    private const string DECK = "DECK";

    private readonly IGame Game;
    private readonly IZone Battlefield;
    public GameBuilder()
    {
        Game = new Game(
            new EventMediator(),
            new ZoneRepository(),
            new CardRepository(),
            new PlayerRepository());
        Game.RegisterSetupCommand(GameSetupCommand.Get(Game));
        Battlefield = new BasicZone(Game, BATTLEFIELD, null);
        Game.Add(Battlefield);
    }
    public GameBuilder WithPlayer(DeckModel deckModel)
    {

        // Création du joueur
        IPlayer player = new Player(Game, deckModel.Id, deckModel.name, deckModel.HeroType);
        Game.Add(player);

        // Création des zones du joueur
        player.RegisterZoneId(BATTLEFIELD, Battlefield.Id);
        foreach (string zoneName in deckModel.SetupModel.Zones)
        {
            if (BATTLEFIELD.Equals(zoneName)) continue;
            IZone zone = new BasicZone(Game, zoneName, player.Id);
            player.RegisterZoneId(zoneName, zone.Id);
            Game.Add(zone);
        }

        // Création des cartes du joueur
        IZone playerDeck = player.GetZone(DECK);
        CardFactory cardFactory = new CardFactory();
        foreach (CardModel cardModel in deckModel)
        {
            ICard card = cardFactory.Create(Game, Guid.NewGuid().ToString(), player.Id, cardModel); 
            Game.Add(card);
            playerDeck.Add(card);
            card.UnTap();
            if (card.IsCardType(CardType.AlterEgo)
                || card.IsCardType(CardType.Hero)
                || card.IsCardType(CardType.Villain)
                || card.IsCardType(CardType.MainSchemeA)
                || card.IsCardType(CardType.MainSchemeB)) continue;
            card.FlipTo("BACK");
        }

        return this;
    }
    public IGame Build() => Game;
}