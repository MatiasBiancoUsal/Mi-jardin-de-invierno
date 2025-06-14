using UnityEngine;
using UnityEngine.UI;

public class PlantaInteractable : MonoBehaviour
{
    public GameObject botonGuardar; // Asignás desde el Inspector (botón global)
    public GameObject iconoUI; // Imagen a guardar
    private Canvas canvas;

    private void Start()
    {
        canvas = FindFirstObjectByType<Canvas>();
    }

    void OnMouseDown()
    {
        // Convertir posición del objeto al espacio de pantalla
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // Mover el botón a esa posición y activarlo
        botonGuardar.transform.position = screenPos;
        botonGuardar.SetActive(true);

        // Guardar referencia a esta planta para usar al hacer clic en el botón
        botonGuardar.GetComponent<BotonGuardar>().plantaActual = this;
    }

    public void GuardarEnInventario()
    {
        PlantInfo info = GetComponent<PlantInfo>();
        ControladorInventario inventario = FindFirstObjectByType<ControladorInventario>();

        Sprite icono = iconoUI.GetComponent<Image>().sprite;
        inventario.AgregarAlInventario(icono, info.plantName, info.season);

        botonGuardar.SetActive(false); // Oculta el botón
        gameObject.SetActive(false);   // Quita la planta del mundo
    }
}
