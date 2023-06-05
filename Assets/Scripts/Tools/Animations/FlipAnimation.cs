using System;
using System.Collections;

using UnityEngine;

public sealed class FlipAnimation : BaseAnimation
{
    private readonly SpriteRenderer SpriteRenderer;
    private readonly Sprite NextSprite;
    private readonly Action MidRoutineAction;

    private FlipAnimation(
            RoutineController routineController,
            Transform transform,
            SpriteRenderer spriteRenderer,
            Sprite nextSprite,
            Action midRoutineAction)
        : base(
            routineController,
            transform)
    {
        SpriteRenderer = spriteRenderer;
        NextSprite = nextSprite;
        MidRoutineAction = midRoutineAction;
    }

    protected override IEnumerator RunAnimation(float delay = 0)
    {
        yield return RoutineController.FlipRoutine(Transform, SpriteRenderer, NextSprite, MidRoutineAction, delay);
    }

    public static IAnimation Get(
                RoutineController routineController,
                Transform transform,
                SpriteRenderer spriteRenderer,
                Sprite nextSprite,
                Action midRoutineAction)
        => new FlipAnimation(
                routineController,
                transform,
                spriteRenderer,
                nextSprite,
                midRoutineAction);
}
