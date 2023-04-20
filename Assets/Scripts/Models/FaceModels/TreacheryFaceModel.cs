using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Treachery Face")]
public sealed class TreacheryFaceModel : CardFaceModel
{
    public TreacheryFaceModel() => CardType = CardType.Treachery;
    public int Boost;
}
