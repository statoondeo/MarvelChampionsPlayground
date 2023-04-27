using System;
public abstract class BaseCard : BaseEntity, ICard
{
    protected BaseCard(IGame game, string cardId, string id, string ownerId, IFacade face, IFacade back)
        : base(game)
    {
        CardId = cardId;
        Id = id;
        OwnerId = ownerId;
        Location = string.Empty;
        Order = 0;
        TapComponent = new TapComponent(false);
        FlipComponent = new FlipComponent(face, back);
    }

    public string CardId { get; private set; }
    public string Id { get; private set; }
    public string OwnerId { get; private set; }
    public string Location { get; private set; }
    public int Order { get; private set; }

    public Action<string> OnLocationChanged { get; set; }
    public Action<int> OnOrderChanged { get; set; }

    public bool IsLocation(string Location) => Location.Equals(Location);
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
    public void MoveTo(string newLocation) => Game.Zones.Get(Game.Players.Get(OwnerId).GetZoneId(newLocation)).AddCard(this);

    #region IFlip

    protected IFlip FlipComponent;
    public IRepository<string, IFacade> Faces => FlipComponent.Faces;
    public IFacade CurrentFace => FlipComponent.CurrentFace;
    public Action<string> OnFlipped { get => FlipComponent.OnFlipped; set => FlipComponent.OnFlipped = value; }
    public void FlipTo(string face) => FlipComponent.FlipTo(face);

    #endregion

    #region ICLassification

    public Classification Classification => CurrentFace.Classification;
    public bool IsClassification(Classification classification)
    {
        foreach (IFace face in FlipComponent.Faces)
            if (face.IsClassification(classification)) return true;
        return false;
    }

    #endregion

    #region ICardType

    public CardType CardType => CurrentFace.CardType;
    public bool IsCardType(CardType cardType)
    {
        foreach (IFace face in FlipComponent.Faces)
            if (face.IsCardType(cardType)) return true;
        return false;
    }

    #endregion

    #region ITapped

    private readonly ITap TapComponent;

    public bool Tapped => TapComponent.Tapped;
    public void Tap() => TapComponent.Tap();
    public void UnTap() => TapComponent.UnTap();
    public Action<bool> OnTapped { get => TapComponent.OnTapped; set => TapComponent.OnTapped = value; }
    public Action<bool> OnUnTapped { get => TapComponent.OnUnTapped; set => TapComponent.OnUnTapped = value; }

    #endregion
}
