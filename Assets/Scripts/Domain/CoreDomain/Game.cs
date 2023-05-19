﻿using System.Collections.Generic;

public sealed class Game : IGame
{
    private ICommand SetupCommand;
    //private readonly IGameMediator Mediator;
    public IPicker<ICard> AnyCardPicker {get; private set;}

    public Game(
        //IGameMediator mediator,
        IRepository<IZone> zones,
        IRepository<ICard> cards, 
        IRepository<IPlayer> players,
        IPicker<ICard> anyCardPicker)
    {
        //Mediator = mediator;
        Zones = zones;
        Cards = cards;
        Players = players;
        AnyCardPicker = anyCardPicker;
    }

    //#region IGameMediator

    //public void Raise(GameEvents eventName) => Mediator.Raise(eventName);
    //public void Raise(GameEvents eventName, IGameArg eventArg) => Mediator.Raise(eventName, eventArg);
    //public void Register(GameEvents eventToListen, Action<IGameArg> callback) => Mediator.Register(eventToListen, callback);
    //public void UnRegister(GameEvents eventToListen, Action<IGameArg> callback) => Mediator.UnRegister(eventToListen, callback);

    //#endregion

    #region IRepository<IPlayer>

    private readonly IRepository<IPlayer> Players;
    public void Add(IPlayer item) => Players.Add(item);
    public void Remove(IPlayer item) => Players.Remove(item);
    public int Count(ISelector<IPlayer> selector) => Players.Count(selector);
    public bool Contains(IPlayer item) => Players.Contains(item);
    public IPlayer GetFirst(ISelector<IPlayer> selector) => Players.GetFirst(selector);
    public IEnumerable<IPlayer> GetAll(ISelector<IPlayer> selector) => Players.GetAll(selector);
    public IPlayer GetLast(ISelector<IPlayer> selector) => Players.GetLast(selector);
    public IPlayer GetAt(ISelector<IPlayer> selector, int index) => Players.GetAt(selector, index);

    #endregion

    #region IRepository<IZone>

    private readonly IRepository<IZone> Zones;
    public void Add(IZone item) => Zones.Add(item);
    public void Remove(IZone item) => Zones.Remove(item);
    public int Count(ISelector<IZone> selector) => Zones.Count(selector);
    public bool Contains(IZone item) => Zones.Contains(item);
    public IZone GetFirst(ISelector<IZone> selector) => Zones.GetFirst(selector);
    public IEnumerable<IZone> GetAll(ISelector<IZone> selector) => Zones.GetAll(selector);
    public IZone GetLast(ISelector<IZone> selector) => Zones.GetLast(selector);
    public IZone GetAt(ISelector<IZone> selector, int index) => Zones.GetAt(selector, index);

    #endregion

    #region ICardContainer

    private readonly IRepository<ICard> Cards;
    public void Add(ICard item) => Cards.Add(item);
    public void Remove(ICard item) => Cards.Remove(item);
    public int Count(ISelector<ICard> selector) => Cards.Count(selector);
    public bool Contains(ICard item) => Cards.Contains(item);
    public ICard GetFirst(ISelector<ICard> selector) => Cards.GetFirst(selector);
    public IEnumerable<ICard> GetAll(ISelector<ICard> selector) => Cards.GetAll(selector);
    public ICard GetLast(ISelector<ICard> selector) => Cards.GetLast(selector);
    public ICard GetAt(ISelector<ICard> selector, int index) => Cards.GetAt(selector, index);

    #endregion

    public void Commit() { } // => Mediator.Raise(GameEvents.OnCommitted);
    public void Setup() => SetupCommand.Execute();
    public void RegisterSetupCommand(ICommand command) => SetupCommand = command;
}
