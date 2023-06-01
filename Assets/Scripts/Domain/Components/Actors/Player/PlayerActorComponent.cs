using System.Collections.Generic;

public sealed class PlayerActorComponent : BaseActorComponent<IPlayerActorComponent>, IPlayerActorComponent
{
    private PlayerActorComponent() : base()
    {
        ActorHolder = StandardActorHolder.Get();
        EncounterCards = new List<ICard>();
    }
    public void Draw(int number) 
    {
        ICard card = Actor.Game.GetLast(
            AndCompositeSelector.Get(
                OwnerIdSelector.Get(Actor.Id), 
                LocationSelector.Get("DECK")));
        card.MoveTo("HAND");
    }
    public IEnumerable<ICard> EncounterCards { get; private set; }

    public static IPlayerActorComponent Get() => new PlayerActorComponent();
}
