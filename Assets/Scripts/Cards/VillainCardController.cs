using UnityEngine;

public sealed class VillainCardController : BaseCardController
{
    [SerializeField] private VillainFaceController FaceController;
    [SerializeField] private VillainFaceController BackController;
    protected override void InitValues()
    {
        IVillainCard card = Card as IVillainCard;
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace(0))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(card.CurrentFace as IVillainFace);
            }
            else
            {
                FacePanelController.SetActive(false);
                BackPanelController.SetActive(true);
                BackController.SetModel(card.CurrentFace as IVillainFace);
            }
        }
        else
        {
            FacePanelController.SetActive(false);
            BackPanelController.SetActive(false);
        }
    }
    public void DealDamage()
        => CompositeCommand.Get(
            DealDamageCommand.Get(Card.Game, Card.CurrentFace as IVillainFace, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    public void HealDamage()
        => CompositeCommand.Get(
            HealDamageCommand.Get(Card.Game, Card.CurrentFace as IVillainFace, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
}
