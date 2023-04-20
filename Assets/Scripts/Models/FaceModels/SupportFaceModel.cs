using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Support Face")]
public sealed class SupportFaceModel : CardFaceModel
{
    public int Cost;
    public int Energy;
    public int Mental;
    public int Physic;
    public int Wild;
    public SupportFaceModel() => CardType = CardType.Support;
}
