using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Environment")]
public sealed class EnvironmentFaceModel : FaceModel
{
    public EnvironmentFaceModel() => FaceType = FaceType.Environment;
    public int Boost;
}
