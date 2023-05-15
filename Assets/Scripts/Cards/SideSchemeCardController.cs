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
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace("FACE"))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(sideSchemeCard.Faces["FACE"] as ISideSchemeFace);
            }
            else
            {
                FacePanelController.SetActive(false);
                BackPanelController.SetActive(true);
                BackController.SetModel(sideSchemeCard.Faces["BACK"] as IBackFace);
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
        if (Card.CurrentFace is not ISideSchemeFace face) return;
        CompositeCommand.Get(
            AddTreatCommand.Get(Card.Game, face, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    }
    public void RemoveTreat()
    {
        if (Card.CurrentFace is not ISideSchemeFace face) return;
        CompositeCommand.Get(
            RemoveTreatCommand.Get(Card.Game, face, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    }
}
