using UnityEngine;

public interface IGrid
{
    Vector2Int Size { get; }
    Vector2 OriginPosition { get; }
    Vector2 CellSize { get; }
    void Set(Vector2Int position, IGridItem item);
    IGridItem Get(Vector2Int position);
    bool IsEmpty(Vector2Int position);
    void Clear(Vector2Int position);
    Vector2 GetWorldPosition(Vector2Int gridPosition);
    Vector2Int GetGridPosition(Vector2 worldPosition);
}
