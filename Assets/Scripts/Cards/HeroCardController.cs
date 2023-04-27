using UnityEngine;

public sealed class HeroCardController : BaseCardController
{
    [SerializeField] private AlterEgoFaceController AlterEgoFaceController;
    [SerializeField] private HeroFaceController HeroFaceController;
    [SerializeField] private LifeController LifeController;

    protected override void OnFlippedCallback(string face)
    {
        base.OnFlippedCallback(face);
        AlterEgoFaceController.gameObject.SetActive(Card.CurrentFace.IsCardType(CardType.AlterEgo));
        HeroFaceController.gameObject.SetActive(!AlterEgoFaceController.gameObject.activeSelf);
    }

    public override void SetData(GameController gameController, RoutineController routineController, ICard card)
    {
        base.SetData(gameController, routineController, card);
        AlterEgoFaceController.SetModel(((IHeroCard)card).Faces.Get("FACE") as IAlterEgoFacade);
        HeroFaceController.SetModel(((IHeroCard)card).Faces.Get("BACK") as IHeroFace);
        LifeController.SetModel((IHeroCard)card);

        OnFlippedCallback(string.Empty);
    }
}
