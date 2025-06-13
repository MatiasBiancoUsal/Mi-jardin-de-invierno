using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonRiego : MonoBehaviour
{
    public Color colorNormal = Color.white;
    public Color colorActivo = Color.green;

    private Image imagenBoton;

    void Start()
    {
        imagenBoton = GetComponent<Image>();
        ActualizarColor();
    }

    public void ToggleModoRiego()
    {
        UIRiego.modoRiego = !UIRiego.modoRiego;
        ActualizarColor();
        Debug.Log("Modo riego: " + UIRiego.modoRiego);

        if (!UIRiego.modoRiego)
        {
            // Desactivar regaderas u otras acciones
        }
    }

    void ActualizarColor()
    {
        if (UIRiego.modoRiego)
            imagenBoton.color = colorActivo;
        else
            imagenBoton.color = colorNormal;
    }

    void Update()
    {
        // Por si se cambia el modo riego desde otro lado, mantiene el color actualizado
        ActualizarColor();
    }
}
