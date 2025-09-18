using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarCartel : MonoBehaviour
{
    public GameObject cartelParaOcultar;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void CartelCerrar()
    {
        // Revisa si el cartel fue asignado para evitar errores.
        if (cartelParaOcultar != null)
        {
            // Desactiva el GameObject del cartel, haciéndolo invisible.
            cartelParaOcultar.SetActive(false);
        }
        else
        {
            Debug.LogWarning("¡Ojo! No asignaste el cartel que se debe cerrar en el script.");
        }
    }
}
