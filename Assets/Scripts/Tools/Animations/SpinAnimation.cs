using System;
using System.Collections;

using UnityEngine;

public sealed class SpinAnimation : BaseAnimation
{
    private readonly Action BeginAction;
    private readonly Action EndAction;

    public SpinAnimation(
            RoutineController routineController,
            Transform transform,
            Action beginAction,
            Action endAction,
            float delay = 0)
        : base(
            routineController,
            transform,
            delay)
    {
        BeginAction = beginAction;
        EndAction = endAction;
    }

    protected override IEnumerator RunAnimation()
    {
        yield return RoutineController.SpinRoutine(Transform, BeginAction, EndAction, Delay);
    }

    public static IAnimation Get(
            RoutineController routineController,
            Transform transform,
            Action beginAction,
            Action endAction,
            float delay = 0)
    => new SpinAnimation(
            routineController,
            transform,
            beginAction,
            endAction,
            delay);
}
