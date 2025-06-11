using UnityEngine;
using UnityEngine.UI;

public class ControladorInventario : MonoBehaviour
{
    public GameObject[] slots;

    public void AgregarAlInventario(Sprite imagen, string nombre, string estacion)
    {
        foreach (GameObject slot in slots)
        {
            Image imagenUI = slot.transform.Find("Imagen").GetComponent<Image>();
            Text nombreTexto = slot.transform.Find("Nombre").GetComponent<Text>();
            Text estacionTexto = slot.transform.Find("Estacion").GetComponent<Text>();

            if (imagenUI.sprite == null)
            {
                imagenUI.sprite = imagen;
                nombreTexto.text = nombre;
                estacionTexto.text = estacion;
                break;
            }
        }
    }
}
