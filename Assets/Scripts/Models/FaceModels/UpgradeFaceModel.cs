using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Upgrade Face")]
public sealed class UpgradeFaceModel : CardFaceModel
{
    public int Cost;
    public int Energy;
    public int Mental;
    public int Physic;
    public int Wild;
    public UpgradeFaceModel() => CardType = CardType.Upgrade;
}
