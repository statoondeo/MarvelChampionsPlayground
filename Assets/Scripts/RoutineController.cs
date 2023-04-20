using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using static Easings;

public sealed class RoutineController : MonoBehaviour
{
    [Header("Color Animation")]
    [SerializeField] private float ColorDuration = .25f;
    [SerializeField] private Method ColorFunction = Method.QuintInOut;

    [Header("Move Animation")]
    [SerializeField] private float MoveDuration = .5f;
    [SerializeField] private Method MoveFunction = Method.QuintInOut;

    [Header("Flip Animation")]
    [SerializeField] private float FlipDuration = .75f;
    [SerializeField] private Method FlipFunction = Method.QuintInOut;

    [Header("Tap Animation")]
    [SerializeField] private float TapDuration = .5f;
    [SerializeField] private Method TapFunction = Method.QuintInOut;

    [Header("Scale Animation")]
    [SerializeField] private float ScaleDuration = .5f;
    [SerializeField] private Method ScaleFunction = Method.QuintInOut;

    [Header("Spin Animation")]
    [SerializeField] private float SpinDuration = 1.0f;
    [SerializeField] private int SpinTurns = 3;
    [SerializeField] private Method SpinFunction = Method.QuintInOut;

    private bool GameStarted = false;
    private List<IEnumerator> Coroutines;
    private Queue<List<IEnumerator>> RoutineQueue;
    private List<Coroutine> RoutineHandlers;
    private void Awake()
    {
        Coroutines = new List<IEnumerator>();
        RoutineQueue = new Queue<List<IEnumerator>>();
    }
    public void StartGame() => GameStarted = true;
    public void Commit()
    {
        if (RoutineQueue.Count > 0)
        {
            if (Coroutines.Count == 0) return;
            RoutineQueue.Enqueue(Coroutines.ToList());
            return;
        }
        if (Coroutines.Count == 0) return;
        RoutineQueue.Enqueue(Coroutines.ToList());
        Coroutines.Clear();
        Execute();
    }
    private int RoutineNumber;
    private void Execute()
    {
        if (RoutineQueue.Count == 0) return;
        List<IEnumerator> routines = RoutineQueue.Peek();
        //while (routines.Count == 0) {
        //    RoutineQueue.Dequeue();
        //    routines = RoutineQueue.Peek();
        //}
        foreach (IEnumerator routine in routines)
        {
            RoutineNumber++;
            StartCoroutine(TrackedRoutine(routine));
        }
    }
    private void EndCommand() 
    {
        RoutineNumber--;
        if (RoutineNumber == 0)
        {
            RoutineQueue.Dequeue();
            Execute();
        }
    }
    private IEnumerator TrackedRoutine(IEnumerator routine)
    {
        yield return StartCoroutine(routine);
        EndCommand();
    }
    private void Register(IEnumerator routine)
    {
        if (GameStarted)
        {
            Coroutines.Add(routine);
            return;
        }
        StartCoroutine(routine);
    }
    public void FlipRoutine(Transform transform, SpriteRenderer spriteRenderer, Sprite nextSprite, float delay = 0)
    {
        Vector2 initialScale = transform.localScale;
        Register(ScaleRoutine(delay, transform, initialScale * new Vector2(.02f, 1), .5f * FlipDuration, Easings.Get(FlipFunction)));
        Register(ExecuteDelayedAction(delay + .5f * FlipDuration, () => spriteRenderer.sprite = nextSprite));
        Register(ScaleRoutine(delay + .5f * FlipDuration, transform, initialScale, .5f * FlipDuration, Easings.Get(FlipFunction)));
    }
    public void TapRoutine(Transform transform, bool tapped)
    {
        Vector3 targetRotationAngles = transform.localRotation.eulerAngles + (tapped ? -90.0f : 90.0f) * Vector3.forward;
        Register(RotateRoutine(0f, transform, Quaternion.Euler(targetRotationAngles), TapDuration, Easings.Get(TapFunction)));
    }
    public void SpinRoutine(Transform transform) 
        => Register(SpinningRoutine(0f, transform, SpinTurns, SpinDuration, Easings.Get(SpinFunction)));
    public void ScaleRoutine(Transform transform, Vector2 targetScale)
        => Register(ScaleRoutine(0f, transform, targetScale, ScaleDuration, Easings.Get(ScaleFunction)));
    public void MoveRoutine(Transform transform, Vector2 targetPosition)
        => Register(MoveRoutine(0f, transform, targetPosition, MoveDuration, Easings.Get(MoveFunction)));
    public void SpriteColorRoutine(SpriteRenderer spriteRenderer, Color targetColor)
        => Register(SpriteColorRoutine(0f, spriteRenderer, targetColor, ColorDuration, Easings.Get(ColorFunction)));

    private IEnumerator ExecuteDelayedAction(float delay, Action action)
    {
        if (!GameStarted)
        {
            action.Invoke();
            yield break;
        }
        if (delay > 0.0f) yield return new WaitForSeconds(delay);
        action.Invoke();
    }
    private IEnumerator ScaleRoutine(float delay, Transform transform, Vector2 targetScale, float duration, Func<float, float> easing)
    {
        if (!GameStarted)
        {
            transform.localScale = targetScale;
            yield break;
        }
        if (delay > 0.0f) yield return new WaitForSeconds(delay);
        Vector2 originalScale = transform.localScale;
        float progress = 0.0f;
        while (progress < duration)
        {
            transform.localScale = Vector2.Lerp(originalScale, targetScale, easing(progress / duration));
            yield return null;
            progress += Time.deltaTime;
        }
        transform.localScale = targetScale;
    }
    private IEnumerator SpriteColorRoutine(float delay, SpriteRenderer spriteRenderer, Color targetColor, float duration, Func<float, float> easing)
    {
        if (!GameStarted)
        {
            spriteRenderer.color = targetColor;
            yield break;
        }
        if (delay > 0.0f) yield return new WaitForSeconds(delay);
        Color originalColor = spriteRenderer.color;
        float progress = 0.0f;
        while (progress < duration)
        {
            spriteRenderer.color = Color.Lerp(originalColor, targetColor, easing(progress / duration));
            yield return null;
            progress += Time.deltaTime;
        }
        spriteRenderer.color = targetColor;
    }
    private IEnumerator RotateRoutine(float delay, Transform transform, Quaternion targetRotation, float duration, Func<float, float> easing)
    {
        if (!GameStarted)
        {
            transform.localRotation = targetRotation;
            yield break;
        }
        if (delay > 0.0f) yield return new WaitForSeconds(delay);
        Quaternion originalRotation = transform.localRotation;
        float progress = 0.0f;
        while (progress < duration)
        {
            transform.localRotation = Quaternion.Lerp(originalRotation, targetRotation, easing(progress / duration));
            yield return null;
            progress += Time.deltaTime;
        }
        transform.localRotation = targetRotation;
    }
    private IEnumerator MoveRoutine(float delay, Transform transform, Vector2 targetPosition, float duration, Func<float, float> easing)
    {
        if (!GameStarted)
        {
            transform.localPosition = targetPosition;
            yield break;
        }
        if (delay > 0.0f) yield return new WaitForSeconds(delay);
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
    private IEnumerator SpinningRoutine(float delay, Transform transform, int nbTurns, float duration, Func<float, float> easing)
    {
        if (!GameStarted) yield break;
        if (delay > 0.0f) yield return new WaitForSeconds(delay);
        float targetRotation = 360.0f * nbTurns;
        float currentRotation = 0;
        float progress = 0;
        while (progress < duration)
        {
            float frameRotation = targetRotation * easing(progress / duration) - currentRotation;
            currentRotation += frameRotation;
            transform.Rotate(0, 0, frameRotation, Space.Self);
            yield return null;
            progress += Time.deltaTime;
        }
    }
}
