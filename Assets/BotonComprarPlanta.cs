using UnityEngine;

public class BotonComprarPlanta : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject botonChecklist;   // Botón oculto que se muestra al comprar
    public GameObject macetaAsociada;   // Maceta que debe aparecer

    // Este método se asigna al botón "Comprar Planta" en el inspector
    public void ComprarPlanta()
    {
        // Ocultar el botón actual
        gameObject.SetActive(false);

        // Mostrar el botón del checklist
        if (botonChecklist != null)
        {
            botonChecklist.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No se asignó el botón checklist en " + name);
        }

        // Activar la maceta correspondiente
        if (macetaAsociada != null)
        {
            macetaAsociada.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No se asignó la maceta asociada en " + name);
        }

        Debug.Log("Planta comprada, checklist activado y maceta mostrada.");
    }
}
