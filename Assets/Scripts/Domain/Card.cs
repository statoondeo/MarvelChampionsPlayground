using System;

public class Card : BaseEntity, ICard
{
    public Card(IGame game, string id, string ownerId, string location, int order, IFace face, IFace back)
        : base(game)
    {
        Id = id;
        OwnerId = ownerId;
        Location = location;
        Order = order;
        Faces = new Repository<string, IFace>();
        CurrentFace = Faces.Register("FACE", face);
        Faces.Register("BACK", back);

        TappedComponent = new TappedComponent(false);
    }

    public string Id { get; private set; }
    public string OwnerId { get; private set; }
    public string Location { get; private set; }
    public int Order { get; private set; }
    public IFace CurrentFace { get; private set; }
    public IRepository<string, IFace> Faces { get; private set; }

    public Action<string> OnFlipped { get; set; }
    public Action<string> OnLocationChanged { get; set; }
    public Action<int> OnOrderChanged { get; set; }

    public void SetLocation(string newLocation)
    {
        Location = newLocation;
        OnLocationChanged?.Invoke(Location);

        if (Game.Players.Get(OwnerId).GetZoneId("BATTLEFIELD").Equals(Location))
        {
            if (CardType == CardType.MainSchemeA)
            {
                Tap();
            }
        }
        if (Game.Players.Get(OwnerId).GetZoneId("HAND").Equals(Location))
        {
            UnTap();
            FlipTo("FACE");
        }
    }
    public void SetOrder(int newOrder)
    {
        Order = newOrder;
        OnOrderChanged?.Invoke(Order);
    }
    public void FlipTo(string face)
    {
        if (!Faces.TryGetValue(face, out IFace newFace)) return;
        if (CurrentFace == newFace) return;
        CurrentFace = newFace;
        OnFlipped?.Invoke(face);
    }
    public void MoveTo(string newLocation) => Game.Zones.Get(Game.Players.Get(OwnerId).GetZoneId(newLocation)).AddCard(this);

    #region ICLassification

    public Classification Classification => CurrentFace.Classification;
    public bool IsClassification(Classification classification)
    {
        foreach (IFace face in Faces)
            if (face.IsClassification(classification)) return true;
        return false;
    }

    #endregion

    #region ICardType

    public CardType CardType => CurrentFace.CardType;
    public bool IsCardType(CardType cardType)
    {
        foreach (IFace face in Faces)
            if (face.IsCardType(cardType)) return true;
        return false;
    }
    public bool IsOneOfCardType(CardType cardType1, CardType cardType2)
    {
        foreach (IFace face in Faces)
            if (face.IsOneOfCardType(cardType1, cardType2)) return true;
        return false;
    }
    public bool IsOneOfCardType(CardType cardType1, CardType cardType2, CardType cardType3)
    {
        foreach (IFace face in Faces)
            if (face.IsOneOfCardType(cardType1, cardType2, cardType3)) return true;
        return false;
    }
    public bool IsOneOfCardType(CardType cardType1, CardType cardType2, CardType cardType3, CardType cardType4)
    {
        foreach (IFace face in Faces)
            if (face.IsOneOfCardType(cardType1, cardType2, cardType3, cardType4)) return true;
        return false;
    }

    #endregion

    #region ITapped

    private readonly ITapped TappedComponent;

    public bool Tapped => TappedComponent.Tapped;
    public void Tap() => TappedComponent.Tap();
    public void UnTap() => TappedComponent.UnTap();
    public Action<bool> OnTapped { get => TappedComponent.OnTapped; set => TappedComponent.OnTapped = value; }
    public Action<bool> OnUnTapped { get => TappedComponent.OnUnTapped; set => TappedComponent.OnUnTapped = value; }

    #endregion
}
