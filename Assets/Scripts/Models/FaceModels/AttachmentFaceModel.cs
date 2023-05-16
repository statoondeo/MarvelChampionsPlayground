using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Faces/Attachment")]
public sealed class AttachmentFaceModel : FaceModel
{
    public AttachmentFaceModel() => FaceType = FaceType.Attachment;
    public int Boost;
}
