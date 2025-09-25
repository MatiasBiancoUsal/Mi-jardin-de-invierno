using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonPlantarControlador : MonoBehaviour
{
    public AnimarSemilla animarSemilla;
    public Color colorActivo = Color.green;

    private Image imagenBoton;
    private Color colorOriginal;

    // 1. Añadimos una variable para recordar el estado
    private bool estaActivo = false;

    void Start()
    {
        imagenBoton = GetComponent<Image>();
        colorOriginal = imagenBoton.color;
    }

    // 2. Renombramos la función para que sea un "Toggle" (interruptor)
    public void ToggleModoPlantar()
    {
        // Si no hemos asignado el script principal, no hacemos nada.
        if (animarSemilla == null)
        {
            Debug.LogError("No has asignado el script 'AnimarSemilla' al botón en el Inspector.");
            return;
        }

        // Invertimos el estado actual
        estaActivo = !estaActivo;

        if (estaActivo)
        {
            // Si AHORA está activo, encendemos todo.
            animarSemilla.ActivarModoPlantar();
            imagenBoton.color = colorActivo;
        }
        else
        {
            // Si AHORA está inactivo (porque lo acabamos de apagar), cancelamos.
            animarSemilla.DesactivarModoPlantar(); // <-- Llamaremos a una nueva función que vamos a crear
            imagenBoton.color = colorOriginal;
        }
    }

    // 3. Modificamos esta función para que también actualice el estado
    public void RestaurarColorOriginal()
    {
        imagenBoton.color = colorOriginal;
        // Le decimos al botón que ya no está activo.
        estaActivo = false;
    }
}
