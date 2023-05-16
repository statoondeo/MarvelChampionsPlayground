using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Support")]
public sealed class SupportFaceModel : FaceModel
{
    public int Cost;
    public int Energy;
    public int Mental;
    public int Physic;
    public int Wild;
    public SupportFaceModel() => FaceType = FaceType.Support;
}
