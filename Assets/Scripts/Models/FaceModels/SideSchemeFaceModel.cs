using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Side Scheme")]
public sealed class SideSchemeFaceModel : FaceModel
{
    public int Starting;
    public int Boost;
    public string WhenRevealedCommand;
    public SideSchemeFaceModel() => FaceType = FaceType.SideScheme;
}
