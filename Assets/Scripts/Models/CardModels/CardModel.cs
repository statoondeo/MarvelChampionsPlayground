using System;

using UnityEngine;

public abstract class CardModel : ScriptableObject
{
    protected CardModel() { }
    public string CardId;
    public CardFaceModel Face;
    public CardFaceModel Back;
}
