using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image icon;
    public Text nameText;
    public Text seasonText;

    public void OnDrop(PointerEventData eventData)
    {
        var dragged = eventData.pointerDrag;
        if (dragged != null)
        {
            PlantInfo info = dragged.GetComponent<PlantInfo>();
            if (info != null)
            {
                icon.sprite = dragged.GetComponent<Image>().sprite;
                nameText.text = info.plantName;
                seasonText.text = info.season;
                icon.enabled = true;
                Destroy(dragged); // Opcional: eliminar de escena al guardar
            }
        }
    }
}

