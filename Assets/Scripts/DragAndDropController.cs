//using UnityEngine;
//public sealed class DragAndDropController : MonoBehaviour
//{
//    private bool IsDragging = false;
//    private Vector3 Offset;
//    private GridController GridController;
//    private CardGridItemController CardController;
//    private Vector2Int InitialGridPosition;
//    private IRoutineService RoutineController;
//    private int InitialSortingLayerID;
//    private void Awake()
//    {
//        CardController = GetComponent<CardGridItemController>();
//        GridController = GetComponentInParent<GridController>();
//        RoutineController = GameManager.Instance.GetService<IRoutineService>();
//    }
//    private void OnMouseDown()
//    {
//        IsDragging = true;
//        InitialSortingLayerID = CardController.SpriteRenderer.sortingLayerID;
//        CardController.SpriteRenderer.sortingLayerID = SortingLayer.NameToID("DragAndDrop");
//        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        Offset = transform.localPosition - mouseWorldPosition;
//        InitialGridPosition = CardController.Position;
//        GridController.Grid.Clear(InitialGridPosition);
//    }
//    private void OnMouseDrag()
//    {
//        if (!IsDragging) return;
//        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Offset;
//        transform.localPosition = new Vector3(newPosition.x, newPosition.y, 0f);
//    }
//    private void OnMouseUp()
//    {
//        CardController.SpriteRenderer.sortingLayerID = InitialSortingLayerID;
//        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        Vector2Int mouseGridPosition = GridController.Grid.GetGridPosition(mouseWorldPosition);
//        IsDragging = false;
//        if (GridController.Grid.IsEmpty(mouseGridPosition))
//        {
//            RoutineController.MoveRoutine(transform, GridController.Grid.GetWorldPosition(mouseGridPosition));
//            GridController.Grid.Set(mouseGridPosition, CardController);
//        }
//        else
//        {
//            RoutineController.MoveRoutine(transform, GridController.Grid.GetWorldPosition(InitialGridPosition));
//            GridController.Grid.Set(InitialGridPosition, CardController);
//        }
//    }
//}
