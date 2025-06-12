using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SemillaClic : MonoBehaviour
{
    public TMP_Text textoContadorSemillas;  // Texto para mostrar el contador de semillas
    private int contadorSemillas = 0;

    void OnMouseDown()
    {
        if (ContadorSemillas.instancia != null)
        {
            ContadorSemillas.instancia.SumarSemilla();
        }
        else
        {
            Debug.LogWarning("No se encontró el ControladorSemillas en la escena.");
        }

        gameObject.SetActive(false);
    }
}
