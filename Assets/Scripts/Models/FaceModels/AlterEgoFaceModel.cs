using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Alter-Ego")]
public sealed class AlterEgoFaceModel : FaceModel
{
    public int Recovery;
    public int HandSize;
    public string SetupCommand;
    public AlterEgoFaceModel()
    {
        FaceType = FaceType.AlterEgo;
        Classification = Classification.Hero;
    }
}
