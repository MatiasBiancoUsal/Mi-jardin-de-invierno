using UnityEngine;

public class PlantaInteractuable : MonoBehaviour
{
    public Sprite imagenPlanta;

    private void OnMouseDown()
    {
        // Llamar al InventarioManager para agregar esta planta
        InventarioManager.Instance.AgregarAlInventario(imagenPlanta);

        // Desactivar o destruir esta planta en la escena
        Destroy(gameObject);
    }
}
