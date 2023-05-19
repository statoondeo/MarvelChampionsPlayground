﻿public sealed class MainSchemeAFace : BaseCardFace, IMainSchemeAFace
{
    #region IStadeFacade

    private readonly IStadeFacade StadeItem;
    public int Stade => StadeItem.Stade;
    public void AddDecorator(ICardComponentDecorator<IStadeComponent> decorator) => StadeItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IStadeComponent> decorator) => StadeItem.RemoveDecorator(decorator);

    #endregion

    #region ISetupFacade

    private readonly ISetupFacade SetupItem;
    public ICommand Setup => SetupItem.Setup;
    public void AddDecorator(ICardComponentDecorator<ISetupComponent> decorator)
        => SetupItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<ISetupComponent> decorator)
        => SetupItem.RemoveDecorator(decorator);

    #endregion

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    public ICommand WhenRevealed => WhenRevealedItem.WhenRevealed;
    public void AddDecorator(ICardComponentDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.RemoveDecorator(decorator);
    public void Reveal() => WhenRevealedItem.Reveal();

    #endregion

    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        StadeItem.SetCard(card);
        SetupItem.SetCard(card);
        WhenRevealedItem.SetCard(card);
        Mediator.GetFacade<IEnterPlayComponent>().SetCard(card);
    }

    #endregion

    #region Constructeur

    private MainSchemeAFace(
            IMediator<ICardComponent> mediator,
            ITitleFacade titleFacade,
            IFaceTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IStadeFacade stadeFacade,
            ISetupFacade setupFacade,
            IEnterPlayFacade enterPlayFacade,
            IWhenRevealedFacade whenRevealedFacade)
        : base(
            mediator,
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        StadeItem = stadeFacade;
        SetupItem = setupFacade;
        WhenRevealedItem = whenRevealedFacade;

        Mediator.Register<IStadeComponent>(StadeItem);
        Mediator.Register<ISetupComponent>(SetupItem);
        Mediator.Register<IWhenRevealedComponent>(WhenRevealedItem);
        Mediator.Register<IEnterPlayComponent>(enterPlayFacade);
    }

    #endregion

    #region Factory

    public static IMainSchemeAFace Get(IMediator<ICardComponent> mediator, MainSchemeAFaceModel faceModel)
        => new MainSchemeAFace(
            mediator,
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            FaceTypeFacade.Get(faceModel.FaceType),
            ClassificationFacade.Get(faceModel.Classification),
            StadeFacade.Get(faceModel.Stade),
            SetupFacade.Get(NullCommand.Get()),
            EnterPlayFacade.Get(SchemeAEnterPlayComponent.Get()),
            WhenRevealedFacade.Get(StaticWhenRevealedComponent.Get(NullCommand.Get())));

    #endregion
}
