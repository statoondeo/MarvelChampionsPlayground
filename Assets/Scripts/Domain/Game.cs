using System.Collections.Generic;
using System.Linq;

public class Game : IGame
{
    public IMediator Mediator { get; private set; }
    public IRepository<string, IZone> Zones { get; private set; }
    public IRepository<string, ICard> Cards { get; private set; }
    public IRepository<string, IPlayer> Players { get; private set; }
    public Game(IMediator mediator)
    {
        Mediator = mediator;
        Zones = new Repository<string, IZone>();
        Cards = new Repository<string, ICard>();
        Players = new Repository<string, IPlayer>();
    }
    public void Setup()
    {
        IPlayer player = Players.Get((IPlayer item) => item.HeroType.Equals(HeroType.Hero)).First();
        IZone battlefield = Zones.Get(player.GetZoneId("BATTLEFIELD"));

        // Put Hero on the battlefield
        ICard hero = Cards.Get(item => item.OwnerId == player.Id && item.IsCardType(CardType.AlterEgo)).First();
        hero.FlipTo("FACE");
        battlefield.AddCard(hero);
        Mediator.Raise(Events.OnGameCommit);

        // Put Obligations on the exil
        IZone playerExil = Zones.Get(player.GetZoneId("EXIL"));
        IEnumerable<ICard> obligations = Cards.Get(item => item.OwnerId == player.Id && item.IsCardType(CardType.Obligation));
        foreach (ICard card in obligations)
        {
            card.FlipTo("FACE");
            playerExil.AddCard(card);
        }
        Mediator.Raise(Events.OnGameCommit);

        // Put nemesis on the exil
        IEnumerable<ICard> nemesis = Cards.Get(item => item.OwnerId == player.Id && item.IsClassification(Classification.Nemesis));
        foreach (ICard card in nemesis)
        {
            card.FlipTo("FACE");
            playerExil.AddCard(card);
        }
        Mediator.Raise(Events.OnGameCommit);

        IZone playerDeck = Zones.Get(player.GetZoneId("DECK"));
        playerDeck.Shuffle();
        Mediator.Raise(Events.OnGameCommit);

        // Put Villain on the battlefield
        IPlayer villainPlayer = Players.Get((IPlayer item) => item.HeroType.Equals(HeroType.Villain)).First();
        ICard villain = Cards.Get(item => item.OwnerId == villainPlayer.Id && item.IsCardType(CardType.Villain)).First();
        villain.FlipTo("FACE");
        battlefield.AddCard(villain);
        Mediator.Raise(Events.OnGameCommit);

        // Put MainSCheme on the battlefield
        ICard mainSCheme = Cards.Get(item => item.OwnerId == villainPlayer.Id && item.IsCardType(CardType.MainSchemeA)).First();
        mainSCheme.FlipTo("FACE");
        battlefield.AddCard(mainSCheme);
        Mediator.Raise(Events.OnGameCommit);

        IZone villainDeck = Zones.Get(villainPlayer.GetZoneId("DECK"));
        villainDeck.Shuffle();
        Mediator.Raise(Events.OnGameCommit);
    }
}
