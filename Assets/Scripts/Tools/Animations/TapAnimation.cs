using System.Collections;

using UnityEngine;

public sealed class TapAnimation : BaseAnimation
{
    private readonly bool Tapped;

    public TapAnimation(
            RoutineController routineController,
            Transform transform,
            bool tapped,
            float delay = 0)
        : base(
            routineController,
            transform,
            delay)
        => Tapped = tapped;

    protected override IEnumerator RunAnimation()
    {
        yield return RoutineController.TapRoutine(Transform, Tapped, Delay);
    }

    public static IAnimation Get(
            RoutineController routineController,
            Transform transform,
            bool tapped,
            float delay = 0)
    => new TapAnimation(
            routineController,
            transform,
            tapped,
            delay);
}
