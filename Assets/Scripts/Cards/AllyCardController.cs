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
        FaceController.SetModel(Card.Faces[0] as IAllyFace);
        BackController.SetModel(Card.Faces[1] as IBackFace);
    }
    public void DealDamage()
    {
        if (Card.CurrentFace is not IAllyFace face) return;
        Card.Game.Enqueue(DealDamageCommand.Get(Card.Game, face, 1));
    }
    public void HealDamage()
    {
        if (Card.CurrentFace is not IAllyFace face) return;
        Card.Game.Enqueue(HealDamageCommand.Get(Card.Game, face, 1));
    }
}
