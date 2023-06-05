using TMPro;

using UnityEngine;

public sealed class CostController : BaseCardComponentController<ICostComponent>
{
    [SerializeField] private TMP_Text Text;
    [SerializeField] private Canvas Canvas;
    protected override void InitValues()
    {        
        Text.text = Model.Cost.ToString();
        Canvas.gameObject.SetActive(((Model as ICardFace).GetFacade<ICostComponent>() is not null) && Model.Card.IsLocation("HAND"));
    }
    public void Play()
    {
    }
}
