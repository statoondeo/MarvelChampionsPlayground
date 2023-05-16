using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Upgrade")]
public sealed class UpgradeFaceModel : FaceModel
{
    public int Cost;
    public int Energy;
    public int Mental;
    public int Physic;
    public int Wild;
    public UpgradeFaceModel() => FaceType = FaceType.Upgrade;
}
