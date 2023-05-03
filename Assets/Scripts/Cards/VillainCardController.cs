using UnityEngine;

public sealed class VillainCardController : BaseCardController
{
    [SerializeField] private VillainFaceController FaceController;
    [SerializeField] private VillainFaceController BackController;

    protected override void OnFlippedCallback(IFlipComponent component)
    {
        base.OnFlippedCallback(component);
        FaceController.gameObject.SetActive(!Card.CurrentFace.IsCardType(CardType.None));
        BackController.gameObject.SetActive(!FaceController.gameObject.activeSelf);
    }

    public override void SetData(GameController gameController, RoutineController routineController, ICard card)
    {
        base.SetData(gameController, routineController, card);
        FaceController.SetModel(card.Faces["FACE"] as IVillainFace);
        BackController.SetModel(card.Faces["BACK"] as IVillainFace);

        OnFlippedCallback(null);
    }
}
