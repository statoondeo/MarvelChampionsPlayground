using System.Collections;

using UnityEngine;
using UnityEngine.Networking.Types;

public sealed class MoveAnimation : BaseAnimation
{
    private readonly Vector2 TargetPosition;

    public MoveAnimation(
            RoutineController routineController,
            Transform transform,
            Vector2 targetPosition)
        : base(
            routineController,
            transform)
        => TargetPosition = targetPosition;

    protected override IEnumerator RunAnimation(float delay = 0)
    {
        yield return RoutineController.MoveRoutine(Transform, TargetPosition, delay);
    }

    public static IAnimation Get(
                RoutineController routineController,
                Transform transform,
                Vector2 targetPosition)
        => new MoveAnimation(
                routineController,
                transform,
                targetPosition);
}
