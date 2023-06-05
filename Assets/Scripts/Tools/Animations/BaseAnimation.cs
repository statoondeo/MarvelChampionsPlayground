using System.Collections;

using UnityEngine;

public abstract class BaseAnimation : IAnimation
{
    protected readonly RoutineController RoutineController;
    protected readonly Transform Transform;
    public bool InProgress { get; protected set; }
    public bool Ended { get; protected set; }

    protected BaseAnimation(
        RoutineController routineController,
        Transform transform)

    {
        Ended = false;
        InProgress = false;
        RoutineController = routineController;
        Transform = transform;
    }

    protected abstract IEnumerator RunAnimation(float delay);

    public IEnumerator Start(float delay = 0)
    {
        InProgress = true;
        yield return RunAnimation(delay);
        Ended = true;
    }
}
