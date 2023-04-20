using UnityEngine;

public interface IGridItem
{
    Vector2Int Position { get; }
    void SetPosition(Vector2Int newPosition);
}
