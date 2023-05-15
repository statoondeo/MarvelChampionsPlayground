public sealed class AllyCardController : BaseCardController
{
    private AllyFaceController FaceController;
    private BackFaceController BackController;

    private void Awake()
    {
        FaceController = FacePanelController.GetComponent<AllyFaceController>();
        BackController = BackPanelController.GetComponent<BackFaceController>();
    }
    protected override void InitValues()
    {
        IAllyCard card = Card as IAllyCard;
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace("FACE"))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(card.Faces["FACE"] as IAllyFace);
            }
            else
            {
                FacePanelController.SetActive(false);
                BackPanelController.SetActive(true);
                BackController.SetModel(card.Faces["BACK"] as IBackFace);
            }
        }
        else
        {
            FacePanelController.SetActive(false);
            BackPanelController.SetActive(false);
        }
    }
    public void DealDamage()
    {
        if (Card.CurrentFace is not IAllyFace face) return;
        CompositeCommand.Get(
            DealDamageCommand.Get(Card.Game, face, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    }
    public void HealDamage()
    {
        if (Card.CurrentFace is not IAllyFace face) return;
        CompositeCommand.Get(
            HealDamageCommand.Get(Card.Game, face, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    }
}
