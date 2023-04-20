using System;
public interface ICard : IEntity, ICardType, ITapped, IClassification
{
    string Id { get; }
    string OwnerId { get; }
    string Location { get; }
    int Order { get; }
    IFace CurrentFace { get; }
    IRepository<string, IFace> Faces { get; }

    Action<string> OnFlipped { get; set; }
    Action<string> OnLocationChanged { get; set; }
    Action<int> OnOrderChanged { get; set; }

    void SetLocation(string newLocation);
    void SetOrder(int newOrder);
    void FlipTo(string face);
    void MoveTo(string location);
}
