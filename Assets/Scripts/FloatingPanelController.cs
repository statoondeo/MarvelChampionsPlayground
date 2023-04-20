using System;
using System.Collections;

using UnityEngine;

using static Easings;

public sealed class FloatingPanelController : MonoBehaviour
{
    [SerializeField] private Vector2 InitialPosition = new(0, -12.3f);
    [SerializeField] private Vector2 TargetPosition = new(0, -4.2f);
    [SerializeField] private float Duration = .5f;
    [SerializeField] private Method Animation = Method.QuintOut;

    private Coroutine DisplayRoutineHandler;

    private void OnMouseEnter()
    {
        if (DisplayRoutineHandler is not null) StopCoroutine(DisplayRoutineHandler);
        DisplayRoutineHandler = StartCoroutine(DisplayRoutine(transform, TargetPosition, Duration, Easings.Get(Animation)));
    }

    private void OnMouseExit()
    {
        if (DisplayRoutineHandler is not null) StopCoroutine(DisplayRoutineHandler);
        DisplayRoutineHandler = StartCoroutine(DisplayRoutine(transform, InitialPosition, Duration, Easings.Get(Animation)));
    }

    private IEnumerator DisplayRoutine(Transform transform, Vector2 targetPosition, float duration, Func<float, float> easing)
    {
        Vector2 originalPosition = transform.localPosition;
        float progress = 0.0f;
        while (progress < duration)
        {
            transform.localPosition = Vector2.Lerp(originalPosition, targetPosition, easing(progress / duration));
            yield return null;
            progress += Time.deltaTime;
        }
        transform.localPosition = targetPosition;
    }
}
