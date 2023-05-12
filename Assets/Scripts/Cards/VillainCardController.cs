using UnityEngine;

public sealed class VillainCardController : BaseCardController
{
    [SerializeField] private VillainFaceController FaceController;
    [SerializeField] private VillainFaceController BackController;

    protected override void OnFlippedCallback(IComponent component)
    {
        base.OnFlippedCallback(component);
        FaceController.gameObject.SetActive(!(Card.CurrentFace as IVillainFace).IsCardType(CardType.None));
        BackController.gameObject.SetActive(!FaceController.gameObject.activeSelf);
    }

    public override void SetData(GameController gameController, RoutineController routineController, ICard card)
    {
        base.SetData(gameController, routineController, card);
        FaceController.SetModel(card.Faces["FACE"] as IVillainFace);
        BackController.SetModel(card.Faces["BACK"] as IVillainFace);

        OnFlippedCallback(null);
    }
    public void DealDamage() => (Card.CurrentFace as IVillainFace)?.TakeDamage(1);

}
