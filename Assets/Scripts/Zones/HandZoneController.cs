using System.Linq;

using UnityEngine;

public sealed class HandZoneController : BaseZoneController
{
    [SerializeField] private Vector2Int LeftGridPosition;
    [SerializeField] private Vector2Int RightGridPosition;
    [SerializeField] private float MaxGap;

    private Vector2 LeftPosition;
    private Vector2 RightPosition;
    private Vector2 CellSize;
    private float HandLength;

    public override void SetData(GameController gameController, IZone zone)
    {
        base.SetData(gameController, zone);
        CellSize = GameController.Grid.CellSize;
        LeftPosition = GameController.Grid.GetWorldPosition(LeftGridPosition) - CellSize.x * Vector2.right;
        RightPosition = GameController.Grid.GetWorldPosition(RightGridPosition) + CellSize.x * Vector2.right;
        HandLength = RightPosition.x - LeftPosition.x;
        transform.position = LeftPosition;
    }
    public override void RefreshContent() => PlaceCards();
    protected override void PlaceCards()
    {
        if (Count == 0) return;
        if (Count == 1)
        {
            BaseCardController controller = GameController
                .CardControllers
                .GetFirst(CardIdControllerSelector.Get(Zone.GetAt(NoFilterCardSelector.Get(), 0).Id));
            GameController.RoutineController.AddAnimation(
                MoveAnimation.Get(
                    GameController.RoutineController,
                    controller.transform,
                    LeftPosition + .5f * HandLength * Vector2.right));
            return;
        }
        float gap = Mathf.Min(MaxGap, (HandLength - CellSize.x * Count) / (Count - 1));
        float currentHandLength = CellSize.x * Count + gap * (Count - 1);
        Vector2 startPosition = new Vector2(LeftPosition.x + .5f * (HandLength - currentHandLength), LeftPosition.y);
        int i = 0;
        float cellGap = CellSize.x + gap;
        Zone
            .GetAll(NoFilterCardSelector.Get())
            .ToList()
            .ForEach(card =>
            {
                BaseCardController controller = GameController.CardControllers.GetFirst(CardIdControllerSelector.Get(card.Id));
                GameController.RoutineController.AddAnimation(
                    MoveAnimation.Get(
                        GameController.RoutineController,
                        controller.transform,
                        startPosition + i * cellGap * Vector2.right));
                i++;
            });
    }
}
