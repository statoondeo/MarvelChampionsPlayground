using System;
using System.Collections.Generic;

public sealed class Game : IGame
{
    private ICommand SetupCommand;
    private readonly IMediator Mediator;
    private readonly IRepository<IZone> Zones;
    private readonly IRepository<ICard> Cards;
    private readonly IRepository<IPlayer> Players;
    public IPicker<ICard> AnyCardPicker {get; private set;}

    public Game(
        IMediator mediator, 
        IRepository<IZone> zones, 
        IRepository<ICard> cards, 
        IRepository<IPlayer> players,
        IPicker<ICard> anyCardPicker)
    {
        Mediator = mediator;
        Zones = zones;
        Cards = cards;
        Players = players;
        AnyCardPicker = anyCardPicker;
    }

    #region IMediator

    public void Raise(Events eventName)=> Mediator.Raise(eventName);
    public void Raise(Events eventName, EventModelArg eventArg) => Mediator.Raise(eventName, eventArg);
    public void Register(Events eventToListen, Action<EventModelArg> callback) => Mediator.Register(eventToListen, callback);
    public void UnRegister(Events eventToListen, Action<EventModelArg> callback) => Mediator.UnRegister(eventToListen, callback);   

    #endregion

    #region IRepository<IPlayer>

    public void Add(IPlayer item) => Players.Add(item);
    public void Remove(IPlayer item) => Players.Remove(item);
    public int Count(ISelector<IPlayer> selector) => Players.Count(selector);
    public bool Contains(IPlayer item) => Players.Contains(item);
    public IPlayer GetFirst(ISelector<IPlayer> selector) => Players.GetFirst(selector);
    public IEnumerable<IPlayer> GetAll(ISelector<IPlayer> selector) => Players.GetAll(selector);

    #endregion

    #region IRepository<IZone>

    public void Add(IZone item) => Zones.Add(item);
    public void Remove(IZone item) => Zones.Remove(item);
    public int Count(ISelector<IZone> selector) => Zones.Count(selector);
    public bool Contains(IZone item) => Zones.Contains(item);
    public IZone GetFirst(ISelector<IZone> selector) => Zones.GetFirst(selector);
    public IEnumerable<IZone> GetAll(ISelector<IZone> selector) => Zones.GetAll(selector);

    #endregion

    #region IRepository<ICard>

    public void Add(ICard item) => Cards.Add(item);
    public void Remove(ICard item) => Cards.Remove(item);
    public int Count(ISelector<ICard> selector) => Cards.Count(selector);
    public bool Contains(ICard item) => Cards.Contains(item);
    public ICard GetFirst(ISelector<ICard> selector) => Cards.GetFirst(selector);
    public IEnumerable<ICard> GetAll(ISelector<ICard> selector) => Cards.GetAll(selector);

    #endregion

    public void Commit() => Mediator.Raise(Events.OnGameCommit);
    public void Setup() => SetupCommand.Execute();
    public void RegisterSetupCommand(ICommand command) => SetupCommand = command;
}
