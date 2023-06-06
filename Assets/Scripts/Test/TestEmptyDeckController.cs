using UnityEngine;

public sealed class TestEmptyDeckController : MonoBehaviour
{
    [SerializeField] private GameController GameController;
    public void TestDiscardDrawHand()
    {
        GameController.RoutineController.StartGame();
        GameController.Game.Start();
        IPlayerActor playerActor = GameController.Game.GetFirst(PlayerTypeSelector.Get(HeroType.Hero)) as IPlayerActor;
        GameController.Game.Enqueue(
            TransactionCommand.Get(
                GameController.Game,
                CompositeCommand.Get(GameController.Game,
                    PlayerDiscardHandCommand.Get(GameController.Game, playerActor.Id),
                    PlayerDrawUpToHandCommand.Get(GameController.Game, playerActor.Id))));
    }
}
