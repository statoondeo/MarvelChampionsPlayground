using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Hero")]
public sealed class HeroFaceModel : CardFaceModel
{
    public int Thwart;
    public int Attack;
    public int Defense;
    public int HandSize;

    public HeroFaceModel()
    {
        CardType = CardType.Hero;
        Classification = Classification.Hero;
    }
}
