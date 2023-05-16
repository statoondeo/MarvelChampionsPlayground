using System;

using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Initial Setup")]
public sealed class InitialSetupModel : ScriptableObject
{
    public ZonePosition[] ZonePositions;
}
[Serializable]
public sealed class CardPositions
{
    public FaceType CardType;
    public Vector2Int[] Positions;
}

[Serializable]
public sealed class ZonePosition
{
    public string ZoneName;
    public Vector2Int Position;
}
