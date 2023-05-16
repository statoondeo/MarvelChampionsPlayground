using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Hero")]
public sealed class HeroFaceModel : FaceModel
{
    public int Thwart;
    public int Attack;
    public int Defense;
    public int HandSize;

    public HeroFaceModel()
    {
        FaceType = FaceType.Hero;
        Classification = Classification.Hero;
    }
}
