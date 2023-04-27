using UnityEngine;

public sealed class DragAndDropController : MonoBehaviour
{
    private bool IsDragging = false;
    private Vector3 Offset;
    private GameController GameController;
    private BaseCardController CardController;
    private Vector2Int InitialGridPosition;
    private int InitialSortingLayerID;
    private void Awake()
    {
        CardController = GetComponent<BaseCardController>();
        GameController = GetComponentInParent<GameController>();
    }
    private void OnMouseDown()
    {
        IsDragging = true;
        InitialSortingLayerID = CardController.GetSpriteLayer();
        CardController.SetSpriteLayer(SortingLayer.NameToID("DragAndDrop"));
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Offset = transform.localPosition - mouseWorldPosition;
        InitialGridPosition = CardController.Position;
        GameController.Grid.Clear(InitialGridPosition);
    }
    private void OnMouseDrag()
    {
        if (!IsDragging) return;
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Offset;
        transform.localPosition = new Vector3(newPosition.x, newPosition.y, 0f);
    }
    private void OnMouseUp()
    {
        CardController.SetSpriteLayer(InitialSortingLayerID);
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2Int mouseGridPosition = GameController.Grid.GetGridPosition(mouseWorldPosition);
        IsDragging = false;
        if (GameController.Grid.IsEmpty(mouseGridPosition))
        {
            GameController.RoutineService.MoveRoutine(transform, GameController.Grid.GetWorldPosition(mouseGridPosition));
            GameController.RoutineService.Commit();
            GameController.Grid.Set(mouseGridPosition, CardController);
        }
        else
        {
            GameController.RoutineService.MoveRoutine(transform, GameController.Grid.GetWorldPosition(InitialGridPosition));
            GameController.RoutineService.Commit();
            GameController.Grid.Set(InitialGridPosition, CardController);
        }
    }
}
