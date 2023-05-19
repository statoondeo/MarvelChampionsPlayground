using System.Collections.Generic;

public abstract class BaseZoneComponent<T> : BaseComponent, IZoneComponent<T> where T : IZoneComponent
{
    protected BaseZoneComponent() : base() { }

    #region IZoneHolder

    public IZone Zone { get; protected set; }
    public void SetZone(IZone zone) => Zone = zone;

    #endregion
}
