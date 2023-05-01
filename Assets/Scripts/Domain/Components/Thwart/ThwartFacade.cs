public sealed class ThwartFacade : BaseComponentFacade<IThwartComponent>, IThwartFacade
{
    private ThwartFacade(IThwartComponent item) : base(item) { }

    #region IThwart

    public int Thwart => Item.Thwart;

    #endregion

    public static IThwartFacade Get(int thwart) => new ThwartFacade(ThwartComponent.Get(thwart));

}