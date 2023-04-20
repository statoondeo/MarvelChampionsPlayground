using System;
using System.Collections;

using UnityEngine;

using static Easings;

public sealed class ZoomController : MonoBehaviour 
{
    [SerializeField] private Camera Camera;
    [SerializeField] private float ZoomFactor = 1.1f;
    [SerializeField] private float ZoomDuration = .25f;
    [SerializeField] private Vector2 ZoonRange = new Vector2(5, 11);
    [SerializeField] private Method ZoonAnimation = Method.QuintOut;
    private float InitialZoom;
    private Coroutine ZoomRoutineHandler;

    private void Awake() => InitialZoom = Camera.orthographicSize;
    public void ZoomIn() => ZoomTo(Camera.orthographicSize / ZoomFactor);
    public void Reset() => ZoomTo(InitialZoom);
    public void ZoomOut() => ZoomTo(Camera.orthographicSize * ZoomFactor);

    private void ZoomTo(float targetZoom)
    {
        if (ZoomRoutineHandler is not null) StopCoroutine(ZoomRoutineHandler);
        ZoomRoutineHandler = StartCoroutine(ZoomRoutine(Camera, Mathf.Clamp(targetZoom, ZoonRange.x, ZoonRange.y), ZoomDuration, Easings.Get(ZoonAnimation)));
    }
    private IEnumerator ZoomRoutine(Camera camera, float targetZoom, float duration, Func<float, float> easing)
    {
        float originalZoom = camera.orthographicSize;
        float progress = 0.0f;
        while (progress < duration)
        {
            camera.orthographicSize = Mathf.Lerp(originalZoom, targetZoom, easing(progress / duration));
            yield return null;
            progress += Time.deltaTime;
        }
        camera.orthographicSize = targetZoom;
    }
}
