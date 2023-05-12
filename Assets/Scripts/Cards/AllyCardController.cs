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
        IAllyCard allyCard = Card as IAllyCard;
        if (Card.IsLocation("BATTLEFIELD") && Card.CurrentFace.IsCardType(CardType.Ally))
        {
            FacePanelController.SetActive(true);
            FaceController.SetModel(allyCard.Faces["FACE"] as IAllyFace);
        }
        else
        {
            FacePanelController.SetActive(false);
        }
        if (Card.IsLocation("BATTLEFIELD") && !Card.CurrentFace.IsCardType(CardType.Ally))
        {
            BackPanelController.SetActive(true);
            BackController.SetModel(allyCard.Faces["BACK"] as IBackFace);
        }
        else
        {
            BackPanelController.SetActive(false);
        }
    }
    public void DealDamage() => (Card.CurrentFace as IAllyFace)?.TakeDamage(1);
}
