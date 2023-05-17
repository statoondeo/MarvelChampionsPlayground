using UnityEngine;

public sealed class UpgradeCardController : BaseCardController
{
    [SerializeField] private UpgradeFaceController FaceController;
    [SerializeField] private BackFaceController BackController;

    protected override void InitValues()
    {
        IUpgradeCard card = Card as IUpgradeCard;
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace(0))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(card.CurrentFace as IUpgradeFace);
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
