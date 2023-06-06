using UnityEngine;

public sealed class TestSetupController : MonoBehaviour
{
    [SerializeField] private GameController GameController;
    public void Setup()
    {
        GameController.RoutineController.StartGame();
        GameController.Game.Start();
        GameController.Game.Setup();
    }
}
