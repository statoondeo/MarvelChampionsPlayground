using UnityEngine;

public sealed class AttachmentCardController : BaseCardController
{
    [SerializeField] private AttachmentFaceController FaceController;
    [SerializeField] private BackFaceController BackController;

    protected override void InitValues()
    {
        IAttachmentCard card = Card as IAttachmentCard;
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace("FACE"))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(card.Faces["FACE"] as IAttachmentFace);
            }
            else
            {
                FacePanelController.SetActive(false);
                BackPanelController.SetActive(true);
                BackController.SetModel(card.Faces["BACK"] as IBackFace);
            }
        }
        else
        {
            FacePanelController.SetActive(false);
            BackPanelController.SetActive(false);
        }
    }
}
