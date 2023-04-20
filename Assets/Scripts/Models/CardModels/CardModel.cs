using System;

using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Cards/Card")]
public class CardModel : ScriptableObject
{
    public CardFaceModel Face;
    public CardFaceModel Back;
}
