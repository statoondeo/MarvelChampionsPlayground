using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Attachment")]
public sealed class AttachmentFaceModel : CardFaceModel
{
    public AttachmentFaceModel() => CardType = CardType.Attachment;
    public int Boost;
}
