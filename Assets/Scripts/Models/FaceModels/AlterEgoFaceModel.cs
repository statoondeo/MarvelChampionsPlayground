﻿using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Alter-Ego")]
public sealed class AlterEgoFaceModel : CardFaceModel
{
    public int Recovery;
    public int HandSize;
    public AlterEgoFaceModel()
    {
        CardType = CardType.AlterEgo;
        Classification = Classification.Hero;
    }
}
