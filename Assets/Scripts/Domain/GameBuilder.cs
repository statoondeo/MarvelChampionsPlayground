using System;

public sealed class GameBuilder
{

    private const string BATTLEFIELD = "BATTLEFIELD";
    private const string DECK = "DECK";

    private readonly IGame Game;
    private readonly IZone Battlefield;
    public GameBuilder()
    {
        Game = new Game(new EventMediator());
        Game.RegisterSetupCommand(GameSetupCommand.Get(Game));
        Battlefield = new BasicZone(Game, BATTLEFIELD, null);
        Game.Zones.Register(Battlefield.Id, Battlefield);
    }
    public GameBuilder WithPlayer(DeckModel deckModel)
    {

        // Création du joueur
        IPlayer player = Game.Players.Register(deckModel.Id, new Player(Game, deckModel.Id, deckModel.name, deckModel.HeroType));

        // Création des zones du joueur
        player.RegisterZoneId(BATTLEFIELD, Battlefield.Id);
        foreach (string zoneName in deckModel.SetupModel.Zones)
        {
            if (BATTLEFIELD.Equals(zoneName)) continue;
            IZone zone = new BasicZone(Game, zoneName, player.Id);
            player.RegisterZoneId(zoneName, zone.Id);
            Game.Zones.Register(zone.Id, zone);
        }

        // Création des cartes du joueur
        Game.Zones.TryGetValue(player.GetZoneId(DECK), out IZone playerDeck);
        CardFactory cardFactory = new CardFactory();
        foreach (CardModel cardModel in deckModel)
        {
            ICard card = cardFactory.Create(Game, Guid.NewGuid().ToString(), player.Id, cardModel); 
            Game.Cards.Register(card.Id, card);
            playerDeck.AddCard(card);
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