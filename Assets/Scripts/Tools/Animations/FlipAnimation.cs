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
            Action midRoutineAction,
            float delay = 0)
        : base(
            routineController,
            transform,
            delay)
    {
        SpriteRenderer = spriteRenderer;
        NextSprite = nextSprite;
        MidRoutineAction = midRoutineAction;
    }

    protected override IEnumerator RunAnimation()
    {
        yield return RoutineController.FlipRoutine(Transform, SpriteRenderer, NextSprite, MidRoutineAction, Delay);
    }

    public static IAnimation Get(
                RoutineController routineController,
                Transform transform,
                SpriteRenderer spriteRenderer,
                Sprite nextSprite,
                Action midRoutineAction,
                float delay = 0)
        => new FlipAnimation(
                routineController,
                transform,
                spriteRenderer,
                nextSprite,
                midRoutineAction,
                delay);
}
