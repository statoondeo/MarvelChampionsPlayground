using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Minion")]
public sealed class MinionFaceModel : FaceModel
{
    public int Scheme;
    public int Attack;
    public int Life;
    public int Boost;
    public string WhenRevealedCommand;
    public MinionFaceModel() => FaceType = FaceType.Minion;
}
