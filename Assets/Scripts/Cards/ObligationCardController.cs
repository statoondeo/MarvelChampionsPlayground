using UnityEngine;

public sealed class ObligationCardController : BaseCardController
{
    [SerializeField] private ObligationFaceController FaceController;
    [SerializeField] private BackFaceController BackController;

    protected override void OnFlippedCallback(IFlipComponent component)
    {
        base.OnFlippedCallback(component);
        FaceController.gameObject.SetActive(!Card.CurrentFace.IsCardType(CardType.None));
        BackController.gameObject.SetActive(!FaceController.gameObject.activeSelf);
    }

    public override void SetData(GameController gameController, RoutineController routineController, ICard card)
    {
        base.SetData(gameController, routineController, card);
        FaceController.SetModel(card.Faces.Get("FACE") as IObligationFace);
        BackController.SetModel(card.Faces.Get("BACK") as IBackFace);

        OnFlippedCallback(null);
    }
}
