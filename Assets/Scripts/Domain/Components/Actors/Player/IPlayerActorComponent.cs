using System.Collections.Generic;

public interface IPlayerActorComponent : IActorComponent<IPlayerActorComponent>
{
    void Draw(int number);
    IEnumerable<ICard> EncounterCards { get; }
}

