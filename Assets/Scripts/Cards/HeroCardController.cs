﻿using UnityEngine;

public sealed class HeroCardController : BaseCardController
{
    [SerializeField] private AlterEgoFaceController AlterEgoFaceController;
    [SerializeField] private HeroFaceController HeroFaceController;
    [SerializeField] private LifeController LifeController;

    protected override void OnFlippedCallback(IFlipComponent component)
    {
        base.OnFlippedCallback(component);
        AlterEgoFaceController.gameObject.SetActive(Card.CurrentFace.IsCardType(CardType.AlterEgo));
        HeroFaceController.gameObject.SetActive(!AlterEgoFaceController.gameObject.activeSelf);
    }

    public override void SetData(GameController gameController, RoutineController routineController, ICard card)
    {
        base.SetData(gameController, routineController, card);

        IHeroCard heroCard = card as IHeroCard;
        AlterEgoFaceController.SetModel(heroCard.Faces.Get("FACE") as IAlterEgoFace);
        HeroFaceController.SetModel(heroCard.Faces.Get("BACK") as IHeroFace);
        LifeController.SetModel(heroCard);

        OnFlippedCallback(null);
    }
}
