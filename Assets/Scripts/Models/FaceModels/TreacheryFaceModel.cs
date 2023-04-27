using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Treachery")]
public sealed class TreacheryFaceModel : CardFaceModel
{
    public TreacheryFaceModel() => CardType = CardType.Treachery;
    public int Boost;
}
