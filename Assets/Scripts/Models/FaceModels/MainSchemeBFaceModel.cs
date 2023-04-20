using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Main Scheme B Face")]
public sealed class MainSchemeBFaceModel : CardFaceModel
{
    public int Starting;
    public int Acceleration;
    public int Threshold;
    public int Stade;
    public MainSchemeBFaceModel()
    {
        CardType = CardType.MainSchemeA;
        Classification = Classification.Villain;
    }
}
