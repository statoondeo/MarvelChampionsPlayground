using System.Collections;

using UnityEngine;
using UnityEngine.Networking.Types;

public sealed class MoveAnimation : BaseAnimation
{
    private readonly Vector2 TargetPosition;

    public MoveAnimation(
            RoutineController routineController,
            Transform transform,
            Vector2 targetPosition,
            float delay = 0)
        : base(
            routineController,
            transform,
            delay)
        => TargetPosition = targetPosition;

    protected override IEnumerator RunAnimation()
    {
        yield return RoutineController.MoveRoutine(Transform, TargetPosition, Delay);
    }

    public static IAnimation Get(
                RoutineController routineController,
                Transform transform,
                Vector2 targetPosition,
                float delay = 0)
        => new MoveAnimation(
                routineController,
                transform,
                targetPosition,
                delay);
}
