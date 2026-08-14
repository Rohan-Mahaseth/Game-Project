using UnityEngine;
using UnityEngine.EventSystems;

// Add this to any UI Button. It scales up on hover and squashes on click.
// Uses unscaled time, so it also works on the WinPanel (when Time.timeScale = 0).
public class ButtonHoverEffect : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler,
    IPointerDownHandler, IPointerUpHandler
{
    public float hoverScale = 1.08f;
    public float pressScale = 0.95f;
    public float speed = 12f;

    private Vector3 targetScale = Vector3.one;

    void OnEnable()
    {
        transform.localScale = Vector3.one;
        targetScale = Vector3.one;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            Time.unscaledDeltaTime * speed
        );
    }

    public void OnPointerEnter(PointerEventData e) { targetScale = Vector3.one * hoverScale; }
    public void OnPointerExit(PointerEventData e)  { targetScale = Vector3.one; }
    public void OnPointerDown(PointerEventData e)  { targetScale = Vector3.one * pressScale; }
    public void OnPointerUp(PointerEventData e)    { targetScale = Vector3.one * hoverScale; }
}
