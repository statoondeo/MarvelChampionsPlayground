using UnityEngine;

public abstract class BaseCardComponentController<T> : MonoBehaviour where T : ICardComponent<T>
{
    protected T Model;
    protected ICardFace AttachedFace;
    protected virtual void OnEnable()
    {
        if (AttachedFace is null) return;
        AttachedFace.AddListener<T>(OnChangedCallback);
        InitValues();
    }
    protected virtual void OnDisable() => AttachedFace?.RemoveListener<T>(OnChangedCallback);
    public virtual void SetModel(T model)
    {
        Model = model;
        AttachedFace = model as ICardFace;
        AttachedFace.AddListener<T>(OnChangedCallback);
        InitValues();
    }
    protected abstract void InitValues();
    protected virtual void OnChangedCallback(IComponent component) => InitValues();
}