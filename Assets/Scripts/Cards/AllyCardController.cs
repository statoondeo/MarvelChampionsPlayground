public sealed class AllyCardController : BaseCardController
{
    private AllyFaceController FaceController;
    private BackFaceController BackController;

    private void Awake()
    {
        FaceController = FacePanelController.GetComponent<AllyFaceController>();
        BackController = BackPanelController.GetComponent<BackFaceController>();
    }
    protected override void InitValues()
    {
        IAllyCard card = Card as IAllyCard;
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace("FACE"))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(card.Faces["FACE"] as IAllyFace);
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
    public void DealDamage() => (Card.CurrentFace as IAllyFace)?.TakeDamage(1);
    public void HealDamage() => (Card.CurrentFace as IAllyFace)?.HealDamage(1);
}
