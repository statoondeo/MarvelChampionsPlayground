using UnityEngine;

public sealed class SelectionController : MonoBehaviour
{
    public ISelectionMediator Mediator { get; private set; }

    private void Awake() => Mediator = StandardSelectionMediator.Get();
}
