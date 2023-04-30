using UnityEngine;

public interface ITitleComponent : IComponent<ITitleComponent>
{
    string Title { get; }
    string SubTitle { get; }
    Sprite Sprite { get; }
}
