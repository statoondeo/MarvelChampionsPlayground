public sealed class MainSchemeCardController : BaseCardController
{
    private MainSchemeAFaceController FaceController;
    private MainSchemeBFaceController BackController;

    private void Awake()
    {
        FaceController = FacePanelController.GetComponent<MainSchemeAFaceController>();
        BackController = BackPanelController.GetComponent<MainSchemeBFaceController>();
    }
    protected override void InitValues()
    {
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.CurrentFace.IsFaceType(FaceType.MainSchemeA))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(Card.CurrentFace as IMainSchemeAFace);
            }
            else
            {
                FacePanelController.SetActive(false);
                BackPanelController.SetActive(true);
                BackController.SetModel(Card.CurrentFace as IMainSchemeBFace);
            }
        }
        else
        {
            FacePanelController.SetActive(false);
            BackPanelController.SetActive(false);
        }
    }
    public void AddTreat()
    {
        if (Card.CurrentFace is not IMainSchemeBFace face) return;
        CompositeCommand.Get(
            AddTreatCommand.Get(Card.Game, face, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    }
    public void RemoveTreat()
    {
        if (Card.CurrentFace is not IMainSchemeBFace face) return;
        CompositeCommand.Get(
            RemoveTreatCommand.Get(Card.Game, face, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    }
}
