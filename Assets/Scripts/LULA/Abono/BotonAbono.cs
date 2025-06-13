using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonAbono : MonoBehaviour
{
    public Color colorNormal = Color.white;
    public Color colorActivo = Color.green;

    private Image imagenBoton;

    void Start()
    {
        imagenBoton = GetComponent<Image>();
        ActualizarColor();
    }

    public void ToggleModoAbono()
    {
        UIAbono.modoAbono = !UIAbono.modoAbono;
        ActualizarColor();
        Debug.Log("Modo abono: " + UIAbono.modoAbono);

        if (!UIAbono.modoAbono)
        {
            // Desactivar aboneras u otras acciones si es necesario
        }
    }

    void ActualizarColor()
    {
        if (UIAbono.modoAbono)
            imagenBoton.color = colorActivo;
        else
            imagenBoton.color = colorNormal;
    }

    void Update()
    {
        // Mantiene el color sincronizado si se cambia desde otro lugar
        ActualizarColor();
    }
}
