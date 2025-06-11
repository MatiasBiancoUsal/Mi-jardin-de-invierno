using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject dragImage;
    private RectTransform dragRect;
    private Canvas canvas;

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragImage = new GameObject("DragImage", typeof(RectTransform), typeof(CanvasGroup), typeof(UnityEngine.UI.Image));
        dragImage.transform.SetParent(canvas.transform, false);
        dragRect = dragImage.GetComponent<RectTransform>();
        dragImage.GetComponent<UnityEngine.UI.Image>().sprite = GetComponent<UnityEngine.UI.Image>().sprite;
        dragImage.GetComponent<CanvasGroup>().blocksRaycasts = false;
        dragRect.sizeDelta = new Vector2(80, 80);
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragRect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(dragImage);
    }
}
