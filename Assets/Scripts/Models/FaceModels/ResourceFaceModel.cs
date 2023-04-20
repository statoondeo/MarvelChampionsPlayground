using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Resource Face")]
public sealed class ResourceFaceModel : CardFaceModel
{
    public int Energy;
    public int Mental;
    public int Physic;
    public int Wild;
    public ResourceFaceModel() => CardType = CardType.Resource;
}
