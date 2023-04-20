using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Hero Face")]
public sealed class HeroFaceModel : CardFaceModel
{
    public int Thwart;
    public int Attack;
    public int Protection;
    public int HandSize;

    public HeroFaceModel()
    {
        CardType = CardType.Hero;
        Classification = Classification.Hero;
    }
}
