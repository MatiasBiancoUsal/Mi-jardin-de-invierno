using UnityEngine;

public class MostrarCartelAlActivar : MonoBehaviour
{
    [Header("Cartel que debe aparecer cuando este objeto se activa")]
    public GameObject cartel;  // el panel o cartel que querés mostrar

    private bool yaMostrado = false;

    void OnEnable()
    {
        if (cartel != null && !yaMostrado)
        {
            cartel.SetActive(true);
            yaMostrado = true;
        }
    }

    void OnDisable()
    {
        // Si se desactiva el pétalo, también ocultamos el cartel (opcional)
        if (cartel != null)
        {
            cartel.SetActive(false);
        }
        yaMostrado = false;
    }
}
