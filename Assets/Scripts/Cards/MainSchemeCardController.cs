public sealed class MainSchemeCardController : BaseCardController
{
    private MainSchemeAFaceController FaceController;
    private MainSchemeBFaceController BackController;

    protected override void Awake()
    {
        base.Awake();
        FaceController = FacePanelController.GetComponent<MainSchemeAFaceController>();
        BackController = BackPanelController.GetComponent<MainSchemeBFaceController>();
    }
    protected override void InitValues()
    {
        FaceController.SetModel(Card.Faces[0] as IMainSchemeAFace);
        BackController.SetModel(Card.Faces[1] as IMainSchemeBFace);
    }
    public void AddTreat()
    {
        if (Card.CurrentFace is not IMainSchemeBFace face) return;
        Card.Game.Enqueue(AddTreatCommand.Get(Card.Game, face, 1));
    }
    public void RemoveTreat()
    {
        if (Card.CurrentFace is not IMainSchemeBFace face) return;
        Card.Game.Enqueue(RemoveTreatCommand.Get(Card.Game, face, 1));
    }
}
