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
            Action endAction)
        : base(
            routineController,
            transform)
    {
        BeginAction = beginAction;
        EndAction = endAction;
    }

    protected override IEnumerator RunAnimation(float delay = 0)
    {
        yield return RoutineController.SpinRoutine(Transform, BeginAction, EndAction, delay);
    }

    public static IAnimation Get(
            RoutineController routineController,
            Transform transform,
            Action beginAction,
            Action endAction)
    => new SpinAnimation(
            routineController,
            transform,
            beginAction,
            endAction);
}
