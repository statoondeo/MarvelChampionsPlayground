using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using static Easings;
public sealed class RoutineController : MonoBehaviour
{
    #region Animation parameters

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

    #endregion

    private bool GameStarted = false;
    public void StartGame() => GameStarted = true;
    private void Awake() => TransactionHandlers = new List<ITransactionHandler>();

    #region Transaction handler

    private IList<ITransactionHandler> TransactionHandlers;
    public void StartTransaction(ITransactionHandler transactionHandler) => TransactionHandlers.Insert(0, transactionHandler);
    public void StopTransaction() => TransactionHandlers.RemoveAt(0);
    public void AddAnimation(IAnimation animation)
    {
        StartCoroutine(animation.Start());
        if (TransactionHandlers.Count == 0) return;
        TransactionHandlers[0].AddAnimation(animation);
    }

    #endregion

    #region Functionals animation

    public IEnumerator FlipRoutine(
        Transform transform,
        SpriteRenderer spriteRenderer,
        Sprite nextSprite,
        Action midRoutineAction,
        float delay = 0)
    {
        Vector2 initialScale = transform.localScale;
        yield return ScaleRoutine(delay, transform, initialScale * new Vector2(.02f, 1), .5f * FlipDuration, Easings.Get(FlipFunction));
        yield return ExecuteDelayedAction(0, () =>
        {
            spriteRenderer.sprite = nextSprite;
            midRoutineAction.Invoke();
        });
        yield return ScaleRoutine(0, transform, initialScale, .5f * FlipDuration, Easings.Get(FlipFunction));
    }
    public IEnumerator TapRoutine(Transform transform, bool tapped, float delay)
    {
        Vector3 targetRotationAngles = transform.localRotation.eulerAngles + (tapped ? -90.0f : 90.0f) * Vector3.forward;
        yield return RotateRoutine(delay, transform, Quaternion.Euler(targetRotationAngles), TapDuration, Easings.Get(TapFunction));
    }
    public IEnumerator SpinRoutine(Transform transform, Action beginAction, Action endAction, float delay)
    {
        beginAction.Invoke();
        yield return SpinningRoutine(delay, transform, SpinTurns, SpinDuration, Easings.Get(SpinFunction));
        beginAction.Invoke();
    }
    public IEnumerator ScaleRoutine(Transform transform, Vector2 targetScale, float delay)
        => ScaleRoutine(delay, transform, targetScale, ScaleDuration, Easings.Get(ScaleFunction));
    public IEnumerator MoveRoutine(Transform transform, Vector2 targetPosition, float delay)
    {
        yield return MoveRoutine(delay, transform, targetPosition, MoveDuration, Easings.Get(MoveFunction));
    }
    public IEnumerator SpriteColorRoutine(SpriteRenderer spriteRenderer, Color targetColor, float delay)
        => SpriteColorRoutine(delay, spriteRenderer, targetColor, ColorDuration, Easings.Get(ColorFunction));

    #endregion

    #region Basic animation

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

    #endregion
}
