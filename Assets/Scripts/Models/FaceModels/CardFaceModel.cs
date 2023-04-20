using UnityEngine;

public abstract class CardFaceModel : ScriptableObject
{
    public bool Unique;
    public string Title;
    public string SubTitle;
    public Sprite Sprite;
    public CardType CardType = CardType.None;
    public Classification Classification = Classification.None;
}
