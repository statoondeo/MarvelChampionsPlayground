using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Villain")]
public sealed class VillainFaceModel : CardFaceModel
{
    public int Scheme;
    public int Attack;
    public int Life;
    public int Stade;
    public VillainFaceModel()
    {
        CardType = CardType.Villain;
        Classification = Classification.Villain;
    }
}
