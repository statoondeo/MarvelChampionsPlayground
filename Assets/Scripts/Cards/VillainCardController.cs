using UnityEngine;

public sealed class VillainCardController : BaseCardController
{
    [SerializeField] private VillainFaceController FaceController;
    [SerializeField] private VillainFaceController BackController;

    protected override void OnFlippedCallback(string face)
    {
        base.OnFlippedCallback(face);
        FaceController.gameObject.SetActive(!Card.CurrentFace.IsCardType(CardType.None));
        BackController.gameObject.SetActive(!FaceController.gameObject.activeSelf);
    }

    public override void SetData(GameController gameController, RoutineController routineController, ICard card)
    {
        base.SetData(gameController, routineController, card);
        FaceController.SetModel(card.Faces.Get("FACE") as IVillainFace);
        BackController.SetModel(card.Faces.Get("BACK") as IVillainFace);

        OnFlippedCallback(string.Empty);
    }
}
