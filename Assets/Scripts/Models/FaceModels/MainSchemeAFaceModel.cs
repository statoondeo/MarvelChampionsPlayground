using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Main Scheme A")]
public sealed class MainSchemeAFaceModel : FaceModel
{
    public int Stade;
    public string SetupCommand;
    public string WhenRevealedCommand;
    public MainSchemeAFaceModel()
    {
        FaceType = FaceType.MainSchemeA;
        Classification = Classification.Villain;
    }
}
