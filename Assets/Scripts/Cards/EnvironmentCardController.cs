using UnityEngine;

public sealed class EnvironmentCardController : BaseCardController
{
    [SerializeField] private EnvironmentFaceController FaceController;
    [SerializeField] private BackFaceController BackController;

    protected override void InitValues()
    {
        IEnvironmentCard card = Card as IEnvironmentCard;
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace(0))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(card.CurrentFace as IEnvironmentFace);
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