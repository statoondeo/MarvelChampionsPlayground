using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Obligation")]
public sealed class ObligationFaceModel : CardFaceModel
{
    public int Boost;
    public ObligationFaceModel() => CardType = CardType.Obligation;
}
