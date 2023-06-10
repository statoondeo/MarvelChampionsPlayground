public sealed class UpgradeCardController : BaseCardController
{
    private UpgradeFaceController FaceController;
    private BackFaceController BackController;

    protected override void Awake()
    {
        base.Awake();
        FaceController = FacePanelController.GetComponent<UpgradeFaceController>();
        BackController = BackPanelController.GetComponent<BackFaceController>();
    }
    protected override void InitValues()
    {
        FaceController.SetModel(Card.Faces[0] as IUpgradeFace);
        BackController.SetModel(Card.Faces[1] as IBackFace);
    }
}
