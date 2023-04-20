using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Main Scheme A Face")]
public sealed class MainSchemeAFaceModel : CardFaceModel
{
    public int Stade;
    public MainSchemeAFaceModel()
    {
        CardType = CardType.MainSchemeA;
        Classification = Classification.Villain;
    }
}
