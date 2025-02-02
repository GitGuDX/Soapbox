using UnityEngine;
using UnityEngine.EventSystems;

public class DockButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalScale * 1.2f; // Scale up
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale; // Reset scale
    }
}
