using UnityEngine;

public interface ITitleComponent : ICardComponent<ITitleComponent>
{
    string Title { get; }
    string SubTitle { get; }
    Sprite Sprite { get; }
}
