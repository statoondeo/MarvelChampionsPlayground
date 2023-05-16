using UnityEngine;

public abstract class CardModel : ScriptableObject
{
    protected CardModel() { }
    public string CardId;
    public CardType CardType;
    public FaceModel Face;
    public FaceModel Back;
}
