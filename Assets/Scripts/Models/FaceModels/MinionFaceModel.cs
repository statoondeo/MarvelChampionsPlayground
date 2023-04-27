using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Minion")]
public sealed class MinionFaceModel : CardFaceModel
{
    public int Scheme;
    public int Attack;
    public int Life;
    public int Boost;
    public MinionFaceModel() => CardType = CardType.Minion;
}
