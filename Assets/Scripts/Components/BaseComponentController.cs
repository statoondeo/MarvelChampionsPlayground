using UnityEngine;

public abstract class BaseComponentController<T> : MonoBehaviour where T : IComponent<T>
{
    protected T Model;
    protected IFace AttachedFace;
    protected virtual void OnEnable()
    {
        if (AttachedFace is null) return;
        AttachedFace.AddListener<T>(OnChangedCallback);
        InitValues();
    }
    protected virtual void OnDisable() => AttachedFace?.RemoveListener<T>(OnChangedCallback);
    public virtual void SetModel(T model)
    {
        Model = model.Card.CurrentFace.GetFacade<T>();
        AttachedFace = Model.Card.CurrentFace;
        AttachedFace.AddListener<T>(OnChangedCallback);
        InitValues();
    }
    protected abstract void InitValues();
    protected virtual void OnChangedCallback(IComponent component) => InitValues();
}