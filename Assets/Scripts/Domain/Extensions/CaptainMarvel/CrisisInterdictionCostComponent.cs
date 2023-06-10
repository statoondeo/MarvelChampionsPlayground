using System.Collections;
using System.Linq;

public sealed class CrisisInterdictionCostComponent : InstantCostComponent
{
    private readonly IPickReceiver<ICard> PickReceiver;
    private CrisisInterdictionCostComponent(int cost) : base(cost) => PickReceiver = StandardCardPickReceiver.Get();
    public override IEnumerator Resolve()
    {
        yield return Card.Game.Pick(
                AndCompositeSelector.Get(
                    LocationSelector.Get("BATTLEFIELD"),
                    OrCompositeSelector.Get(
                        CardTypeSelector.Get(CardType.MainScheme),
                        CardTypeSelector.Get(CardType.SideScheme))),
            PickReceiver, 
            (Card.CurrentFace as ITitleComponent).Title, 
            "Choisissez une manigance");
        if ((PickReceiver.SelectedItems is null) || (PickReceiver.SelectedItems.Count() == 0)) yield break;
        (PickReceiver.SelectedItems.ElementAt(0).CurrentFace as ITreatComponent).RemoveTreat(2);
        yield return Card.Game.Pick(
                AndCompositeSelector.Get(
                    LocationSelector.Get("BATTLEFIELD"),
                    NotCardSelector.Get(PickReceiver.SelectedItems.ElementAt(0).Id),
                    OrCompositeSelector.Get(
                        CardTypeSelector.Get(CardType.MainScheme),
                        CardTypeSelector.Get(CardType.SideScheme))),
            PickReceiver,
            (Card.CurrentFace as ITitleComponent).Title,
            "Choisissez une manigance");
        if ((PickReceiver.SelectedItems is null) || (PickReceiver.SelectedItems.Count() == 0)) yield break;
        (PickReceiver.SelectedItems.ElementAt(0).CurrentFace as ITreatComponent).RemoveTreat(2);
        yield return base.Resolve();
    }
    public static new ICostComponent Get(int cost) => new CrisisInterdictionCostComponent(cost);
}
