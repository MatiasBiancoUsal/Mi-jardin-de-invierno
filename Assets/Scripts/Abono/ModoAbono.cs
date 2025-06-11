using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModoAbono : MonoBehaviour
{
    public static bool activo = false;

    [Header("Opcional: botón para cambiar color")]
    public Button botonAbono; // Asignalo desde el Inspector
    public Color colorActivo = new Color(0.4f, 0.8f, 0.4f); // Verde claro
    public Color colorNormal = Color.white;

    public void ToggleAbono()
    {
        activo = !activo;
        Debug.Log("Modo abono: " + activo);

        // Cambiar color del botón
        if (botonAbono != null)
        {
            var image = botonAbono.GetComponent<Image>();
            if (image != null)
                image.color = activo ? colorActivo : colorNormal;
        }

        // Mostrar contadores si se activa
        AbonoMaceta[] macetas = FindObjectsOfType<AbonoMaceta>();
        foreach (var maceta in macetas)
        {
            if (activo)
                maceta.Activar();
        }
    }
}
