using UnityEngine;

public abstract class FaceModel : ScriptableObject
{
    public bool Unique;
    public string Title;
    public string SubTitle;
    public Sprite Sprite;
    public FaceType FaceType = FaceType.None;
    public Classification Classification = Classification.None;
}
