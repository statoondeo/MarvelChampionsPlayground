using UnityEngine;

public sealed class CardTypeSelectorController : MonoBehaviour
{
    [SerializeField] private GameObject[] GameObjects;

    public void SelectGameObject(GameObject go)
    {
        foreach(GameObject gameObject in GameObjects) gameObject.SetActive(false);
        go.gameObject.SetActive(true);
    }
}
