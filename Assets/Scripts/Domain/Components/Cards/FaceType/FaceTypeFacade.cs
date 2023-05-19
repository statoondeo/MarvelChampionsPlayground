public sealed class FaceTypeFacade : BaseCardComponentFacade<IFaceTypeComponent>, IFaceTypeFacade
{
    private FaceTypeFacade(IFaceTypeComponent item) : base(item) { }
    public FaceType FaceType => Item.FaceType;
    public bool IsFaceType(FaceType faceType) => Item.IsFaceType(faceType);
    public static IFaceTypeFacade Get(FaceType faceType) => new FaceTypeFacade(FaceTypeComponent.Get(faceType));
}