using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class contador : MonoBehaviour
{
    public int puntos = 0;
    public TextMeshProUGUI textoPuntos;  // Arrastrá el texto desde el Inspector

    public void SumarPunto()
    {
        puntos++;
        ActualizarTexto();
    }

    public void GastarSemillas()
    {
        if (puntos >= 2)
        {
            puntos -= 2;
            ActualizarTexto();
        }
        else
        {
            Debug.Log("No hay suficientes semillas.");
        }
    }

    void ActualizarTexto()
    {
        if (textoPuntos != null)
        {
            textoPuntos.text = puntos.ToString();
        }
    }
}

