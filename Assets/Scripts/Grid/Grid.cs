using UnityEngine;
public sealed class Grid : IGrid
{
    public Vector2Int Size { get; private set; }
    public Vector2 OriginPosition { get; private set; }
    public Vector2 CellSize { get; private set; }
    private readonly IGridItem[,] Data;

    public Grid(Vector2Int size, Vector2 cellSize)
    {
        Size = size;
        Data = new IGridItem[Size.x, Size.y];
        CellSize = cellSize;
        OriginPosition = -.5f * CellSize * Size;
    }
    public Vector2 GetWorldPosition(Vector2Int gridPosition) => OriginPosition + CellSize * gridPosition + .5f * CellSize;
    public Vector2Int GetGridPosition(Vector2 worldPosition) => Vector2Int.FloorToInt((worldPosition - OriginPosition) / CellSize);
    public void Set(Vector2Int position, IGridItem item)
    {
        Data[position.x, position.y] = item;
        item.SetPosition(position);
    }
    public IGridItem Get(Vector2Int position) => Data[position.x, position.y];
    public bool IsEmpty(Vector2Int position) => Data[position.x, position.y] is null;
    public void Clear(Vector2Int position) => Data[position.x, position.y] = null;
}