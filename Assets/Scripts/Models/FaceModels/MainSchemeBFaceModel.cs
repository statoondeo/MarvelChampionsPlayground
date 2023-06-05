using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Main Scheme B")]
public sealed class MainSchemeBFaceModel : FaceModel
{
    public int Starting;
    public int Acceleration;
    public int Threshold;
    public int Stade;
    public string WhenRevealedCommand;
    public MainSchemeBFaceModel()
    {
        FaceType = FaceType.MainSchemeA;
        Classification = Classification.Villain;
    }
}
