using System.Collections;

using UnityEngine;

public sealed class TapAnimation : BaseAnimation
{
    private readonly bool Tapped;

    public TapAnimation(
            RoutineController routineController,
            Transform transform,
            bool tapped)
        : base(
            routineController,
            transform)
        => Tapped = tapped;

    protected override IEnumerator RunAnimation(float delay = 0)
    {
        yield return RoutineController.TapRoutine(Transform, Tapped, delay);
    }

    public static IAnimation Get(
            RoutineController routineController,
            Transform transform,
            bool tapped)
    => new TapAnimation(
            routineController,
            transform,
            tapped);
}
