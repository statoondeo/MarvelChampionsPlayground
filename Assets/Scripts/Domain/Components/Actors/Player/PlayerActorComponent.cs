using System.Collections.Generic;

public sealed class PlayerActorComponent : BaseActorComponent<IPlayerActorComponent>, IPlayerActorComponent
{
    private PlayerActorComponent() : base()
    {
        ActorHolder = StandardActorHolder.Get();
        EncounterCards = new List<ICard>();
    }
    public void Draw(int number) { }
    public IEnumerable<ICard> EncounterCards { get; private set; }

    public static IPlayerActorComponent Get() => new PlayerActorComponent();
}
