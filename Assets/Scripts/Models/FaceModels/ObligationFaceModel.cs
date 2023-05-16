using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Obligation")]
public sealed class ObligationFaceModel : FaceModel
{
    public int Boost;
    public ObligationFaceModel() => FaceType = FaceType.Obligation;
}
