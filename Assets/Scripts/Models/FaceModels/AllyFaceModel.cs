using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Ally Face")]
public sealed class AllyFaceModel : CardFaceModel
{
    public int Thwart;
    public int Attack;
    public int Life;
    public int Cost;
    public int Energy;
    public int Mental;
    public int Physic;
    public int Wild;
    public AllyFaceModel() => CardType = CardType.Ally;
}
