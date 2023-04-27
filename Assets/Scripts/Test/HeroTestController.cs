using Unity.VisualScripting;

using UnityEngine;

public sealed class HeroTestController : MonoBehaviour
{
    [SerializeField] private HeroCardModel HeroModel;
    private BaseCardController CardController;
    private IHeroCard HeroCard;

    private void Awake()
    {
        CardController = GetComponent<BaseCardController>();
        HeroCard = new CardFactory().Create(new GameBuilder().Build(), string.Empty, string.Empty, HeroModel) as IHeroCard;
        RoutineController routineController = transform.AddComponent<RoutineController>();
        routineController.StartGame();
        CardController.SetData(null, routineController, HeroCard);
    }

}
