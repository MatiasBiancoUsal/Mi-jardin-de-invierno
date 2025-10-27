using UnityEngine;

public class BotonComprarPlanta : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject botonChecklist;  
    public GameObject macetaAsociada;   

    public void ComprarPlanta()
    {
        
        gameObject.SetActive(false);

       
        if (botonChecklist != null)
        {
            botonChecklist.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No se asignó el botón checklist en " + name);
        }

        // Activa la maceta 
        if (macetaAsociada != null)
        {
            macetaAsociada.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No se asignó la maceta asociada en " + name);
        }

        Debug.Log("Acción tutorial: botón de compra oculto, checklist y maceta activados.");
    }
}