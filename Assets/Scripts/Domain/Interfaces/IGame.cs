﻿public interface IGame
{
    IMediator Mediator { get; }
    IRepository<string, IZone> Zones { get; }
    IRepository<string, ICard> Cards { get; }
    IRepository<string, IPlayer> Players { get; }
    void Setup();
}
