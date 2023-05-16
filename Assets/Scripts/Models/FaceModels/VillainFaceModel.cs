using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Villain")]
public sealed class VillainFaceModel : FaceModel
{
    public int Scheme;
    public int Attack;
    public int Life;
    public int Stade;
    public VillainFaceModel()
    {
        FaceType = FaceType.Villain;
        Classification = Classification.Villain;
    }
}
