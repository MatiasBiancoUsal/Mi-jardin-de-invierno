using UnityEngine;
using UnityEngine.UI;

public class InventarioManager : MonoBehaviour
{
    public static InventarioManager Instance;

    public GameObject prefabSlotInventario;
    public Transform contenedorSlots;

    private void Awake()
    {
        // Singleton para acceder desde cualquier script
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AgregarAlInventario(Sprite imagen)
    {
        GameObject nuevoSlot = Instantiate(prefabSlotInventario, contenedorSlots);
        Image imagenSlot = nuevoSlot.transform.Find("Imagen").GetComponent<Image>();
        imagenSlot.preserveAspect = true;
        imagenSlot.sprite = imagen;
        Debug.Log("Sprite de planta enviado al inventario: " + imagen.name);
    }
}
