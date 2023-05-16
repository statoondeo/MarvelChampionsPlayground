public sealed class FaceTypeComponent : BaseComponent<IFaceTypeComponent>, IFaceTypeComponent
{
    public FaceType FaceType { get; private set; }
    private FaceTypeComponent(FaceType faceType) : base()
    {
        FaceType = faceType;
    }
    public bool IsFaceType(FaceType faceType) => FaceType == faceType;
    public static IFaceTypeComponent Get(FaceType faceType) => new FaceTypeComponent(faceType);
}
