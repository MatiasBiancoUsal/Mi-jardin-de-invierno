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

    void Start()
    {
        imagenBoton = GetComponent<Image>();
        colorOriginal = imagenBoton.color;
    }

   
    public void ActivarModoPlantarEnScript()
    {
       
        if (animarSemilla != null)
        {
            animarSemilla.ActivarModoPlantar();

            
            imagenBoton.color = colorActivo;
        }
        else
        {
            Debug.LogError("No has asignado el script 'AnimarSemilla' al botón en el Inspector.");
        }
    }

    
    public void RestaurarColorOriginal()
    {
        imagenBoton.color = colorOriginal;
    }
}
