using UnityEngine;

public sealed class HeroCardController : BaseCardController
{
    private AlterEgoFaceController FaceController;
    private HeroFaceController BackController;

    private void Awake()
    {
        FaceController = FacePanelController.GetComponent<AlterEgoFaceController>();
        BackController = BackPanelController.GetComponent<HeroFaceController>();
    }
    protected override void InitValues()
    {
        FaceController.SetModel(Card.Faces[0] as IAlterEgoFace);
        BackController.SetModel(Card.Faces[1] as IHeroFace);
    }
    public void DealDamage()
        => Card.Game.Enqueue(DealDamageCommand.Get(Card.Game, Card as IHeroCard, 1));
    public void HealDamage()
        => Card.Game.Enqueue(HealDamageCommand.Get(Card.Game, Card as IHeroCard, 1));
}
