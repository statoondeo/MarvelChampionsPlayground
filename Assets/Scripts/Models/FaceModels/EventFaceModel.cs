using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Event")]
public sealed class EventFaceModel : CardFaceModel
{
    public int Cost;
    public int Energy;
    public int Mental;
    public int Physic;
    public int Wild;
    public EventFaceModel() => CardType = CardType.Event;
}
