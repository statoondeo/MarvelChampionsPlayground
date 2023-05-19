public sealed class ResourceCardController : BaseCardController
{
    private ResourceFaceController FaceController;
    private BackFaceController BackController;

    private void Awake()
    {
        FaceController = FacePanelController.GetComponent<ResourceFaceController>();
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
            FaceController.SetModel(Card.CurrentFace as IResourceFace);
            return;
        }
        FacePanelController.SetActive(false);
        BackPanelController.SetActive(true);
        BackController.SetModel(Card.CurrentFace as IBackFace);
    }
}