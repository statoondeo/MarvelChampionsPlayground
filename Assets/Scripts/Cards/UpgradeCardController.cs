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
            if (Card.IsFace("FACE"))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(card.Faces["FACE"] as IUpgradeFace);
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
