public sealed class EventCardController : BaseCardController
{
    private EventFaceController FaceController;
    private BackFaceController BackController;

    private void Awake()
    {
        FaceController = FacePanelController.GetComponent<EventFaceController>();
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
            FaceController.SetModel(Card.CurrentFace as IEventFace);
            return;
        }
        FacePanelController.SetActive(false);
        BackPanelController.SetActive(true);
        BackController.SetModel(Card.CurrentFace as IBackFace);
    }
}
