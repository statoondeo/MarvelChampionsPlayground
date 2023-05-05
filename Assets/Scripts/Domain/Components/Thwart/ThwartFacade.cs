public sealed class ThwartFacade : BaseFacade<IThwartComponent>, IThwartFacade
{
    private ThwartFacade(IThwartComponent item) : base(item) { }
    public int Thwart => Item.Thwart;
    public static IThwartFacade Get(int thwart) => new ThwartFacade(ThwartComponent.Get(thwart));

}