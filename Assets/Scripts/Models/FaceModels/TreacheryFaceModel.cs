using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Treachery")]
public sealed class TreacheryFaceModel : FaceModel
{
    public TreacheryFaceModel() => FaceType = FaceType.Treachery;
    public int Boost;
}
