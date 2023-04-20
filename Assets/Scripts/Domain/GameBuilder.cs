using System;
using System.Security.Cryptography.X509Certificates;

public sealed class GameBuilder
{

    private const string BATTLEFIELD = "BATTLEFIELD";
    private const string DECK = "DECK";

    private readonly IGame Game;
    private readonly IZone Battlefield;
    public GameBuilder()
    {
        Game = new Game(new EventMediator());
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
        foreach (CardModel cardModel in deckModel)
        {
            ICard card = new CardBuilder(Game, player.Id)
                .WithId(Guid.NewGuid().ToString())
                .WithFace(new FaceBuilder(cardModel.Face.Title, cardModel.Face.Sprite)
                    .WithCardType(new CardTypeComponent(cardModel.Face.CardType))
                    .WithClassification(new ClassificationComponent(cardModel.Face.Classification))
                    .Build())
                .WithBack(new FaceBuilder(cardModel.Back.Title, cardModel.Back.Sprite)
                    .WithCardType(new CardTypeComponent(cardModel.Back.CardType))
                    .WithClassification(new ClassificationComponent(cardModel.Back.Classification))
                    .Build())
                .WithLocation(string.Empty)
                .Build();
            Game.Cards.Register(card.Id, card);
            playerDeck.AddCard(card);
            if (!card.IsOneOfCardType(CardType.Hero, CardType.AlterEgo, CardType.Villain, CardType.MainSchemeA)) card.FlipTo("BACK");
            card.UnTap();
        }

        return this;
    }
    public IGame Build() => Game;
}