using System;

public interface ICard : IEntity, ICardType, IFlip, ITap, IClassification
{
    string CardId { get; }
    string Id { get; }
    string OwnerId { get; }
    string Location { get; }
    int Order { get; }

    Action<string> OnLocationChanged { get; set; }
    Action<int> OnOrderChanged { get; set; }

    bool IsLocation(string location);
    void SetLocation(string newLocation);
    void SetOrder(int newOrder);
    void MoveTo(string location);
}
