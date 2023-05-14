using UnityEngine;

public sealed class MinionCardController : BaseCardController
{
    [SerializeField] private MinionFaceController FaceController;
    [SerializeField] private BackFaceController BackController;
    protected override void InitValues()
    {
        IMinionCard card = Card as IMinionCard;
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace("FACE"))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(card.Faces["FACE"] as IMinionFace);
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
    public void DealDamage() => (Card.CurrentFace as IMinionFace)?.TakeDamage(1);
    public void HealDamage() => (Card.CurrentFace as IMinionFace)?.HealDamage(1);
}
