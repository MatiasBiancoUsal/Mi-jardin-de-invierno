using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonPlantar : MonoBehaviour
{
    public Color colorActivo = Color.green;

    private Image imagenBoton;
    private Color colorOriginal;
    private bool estaActivo = false;

    // Start se llama antes del primer frame. Es ideal para configurar.
    void Start()
    {
      
        imagenBoton = GetComponent<Image>();

       
        colorOriginal = imagenBoton.color;
    }

   
    public void CambiarColor()
    {
      
        estaActivo = !estaActivo;

       
        if (estaActivo)
        {
          
            imagenBoton.color = colorActivo;
        }
        else
        {
      
            imagenBoton.color = colorOriginal;
        }
    }
}
