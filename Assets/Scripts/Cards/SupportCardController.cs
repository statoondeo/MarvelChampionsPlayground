using UnityEngine;

public sealed class SupportCardController : BaseCardController
{
    [SerializeField] private SupportFaceController FaceController;
    [SerializeField] private BackFaceController BackController;

    protected override void InitValues()
    {
        ISupportCard card = Card as ISupportCard;
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace(0))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(card.CurrentFace as ISupportFace);
            }
            else
            {
                FacePanelController.SetActive(false);
                BackPanelController.SetActive(true);
                BackController.SetModel(card.CurrentFace as IBackFace);
            }
        }
        else
        {
            FacePanelController.SetActive(false);
            BackPanelController.SetActive(false);
        }
    }
}
