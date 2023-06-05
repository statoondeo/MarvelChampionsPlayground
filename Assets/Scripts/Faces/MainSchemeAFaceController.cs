using UnityEngine;

public sealed class MainSchemeAFaceController : MonoBehaviour
{
    [SerializeField] private AccelerationTokenController AccelerationTokenController;
    public void SetModel(IMainSchemeAFace model) => AccelerationTokenController.SetModel(model);
}
