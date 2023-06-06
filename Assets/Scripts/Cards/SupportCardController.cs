public sealed class SupportCardController : BaseCardController
{
    private SupportFaceController FaceController;
    private BackFaceController BackController;

    private void Awake()
    {
        FaceController = FacePanelController.GetComponent<SupportFaceController>();
        BackController = BackPanelController.GetComponent<BackFaceController>();
    }
    protected override void InitValues()
    {
        FaceController.SetModel(Card.Faces[0] as ISupportFace);
        BackController.SetModel(Card.Faces[1] as IBackFace);
    }
}
