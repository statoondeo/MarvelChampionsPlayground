using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Environment")]
public sealed class EnvironmentFaceModel : CardFaceModel
{
    public EnvironmentFaceModel() => CardType = CardType.Environment;
    public int Boost;
}
