public sealed class SideSchemeCardController : BaseCardController
{
    private SideSchemeFaceController FaceController;
    private BackFaceController BackController;

    private void Awake()
    {
        FaceController = FacePanelController.GetComponent<SideSchemeFaceController>();
        BackController = BackPanelController.GetComponent<BackFaceController>();
    }
    protected override void InitValues()
    {
        ISideSchemeCard sideSchemeCard = Card as ISideSchemeCard;
        if (Card.IsLocation("BATTLEFIELD") && Card.CurrentFace.IsCardType(CardType.SideScheme))
        {
            FacePanelController.SetActive(true);
            FaceController.SetModel(sideSchemeCard.Faces["FACE"] as ISideSchemeFace);
        }
        else
        {
            FacePanelController.SetActive(false);
        }
        if (Card.IsLocation("BATTLEFIELD") && !Card.CurrentFace.IsCardType(CardType.SideScheme))
        {
            BackPanelController.SetActive(true);
            BackController.SetModel(sideSchemeCard.Faces["BACK"] as IBackFace);
        }
        else
        {
            BackPanelController.SetActive(false);
        }
    }
}
