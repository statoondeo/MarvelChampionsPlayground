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
        FaceController.SetModel(Card.Faces[0] as IEventFace);
        BackController.SetModel(Card.Faces[1] as IBackFace);
    }
}
