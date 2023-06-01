using System.Collections;

using UnityEngine;

public abstract class BaseAnimation : IAnimation
{
    protected readonly RoutineController RoutineController;
    protected readonly Transform Transform;
    protected readonly float Delay;
    public bool InProgress { get; protected set; }
    public bool Ended { get; protected set; }

    protected BaseAnimation(
        RoutineController routineController,
            Transform transform,
        float delay = 0)

    {
        Ended = false;
        InProgress = false;
        RoutineController = routineController;
        Transform = transform;
        Delay = delay;
    }

    protected abstract IEnumerator RunAnimation();

    public IEnumerator Start()
    {
        InProgress = true;
        yield return RunAnimation();
        Ended = true;
    }
}
