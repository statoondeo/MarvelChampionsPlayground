public sealed class StackZoneController : BaseZoneController
{
    public override void RefreshContent()
    {
        transform.localPosition = GameController.Grid.GetWorldPosition(Position);
        PlaceCards();
    }
}
