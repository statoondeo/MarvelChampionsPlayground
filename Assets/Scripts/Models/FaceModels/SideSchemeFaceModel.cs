﻿using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Side Scheme")]
public sealed class SideSchemeFaceModel : CardFaceModel
{
    public int Starting;
    public int Boost;
    public SideSchemeFaceModel() => CardType = CardType.SideScheme;
}
