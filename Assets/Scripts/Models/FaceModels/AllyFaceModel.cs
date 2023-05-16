using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Ally")]
public sealed class AllyFaceModel : FaceModel
{
    public int Thwart;
    public int Attack;
    public int Life;
    public int Cost;
    public int Energy;
    public int Mental;
    public int Physic;
    public int Wild;
    public AllyFaceModel() => FaceType = FaceType.Ally;
}
