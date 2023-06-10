public sealed class TreacheryCardController : BaseCardController
{
    private TreacheryFaceController FaceController;
    private BackFaceController BackController;

    protected override void Awake()
    {
        base.Awake();
        FaceController = FacePanelController.GetComponent<TreacheryFaceController>();
        BackController = BackPanelController.GetComponent<BackFaceController>();
    }
    protected override void InitValues()
    {
        if (Card.IsLocation("STACK"))
        {
            FacePanelController.SetActive(false);
            BackPanelController.SetActive(false);
            return;
        }
        if (Card.IsFace(0))
        {
            BackPanelController.SetActive(false);
            FacePanelController.SetActive(true);
            FaceController.SetModel(Card.CurrentFace as ITreacheryFace);
            return;
        }
        FacePanelController.SetActive(false);
        BackPanelController.SetActive(true);
        BackController.SetModel(Card.CurrentFace as IBackFace);
    }
}
