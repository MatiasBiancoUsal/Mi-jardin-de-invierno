using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class contador : MonoBehaviour
{
    public TextMeshProUGUI textoPuntos;  // Arrastrá el texto desde el Inspector

    public void SumarPunto()
    {
        var puntos = int.Parse(textoPuntos.text);
        puntos++;
        ActualizarTexto(puntos);
    }

    public void GastarSemillas()
    {
        var puntos = int.Parse(textoPuntos.text);
        if (puntos >= 2)
        {
            puntos -= 2;
            ActualizarTexto(puntos);
        }
        else
        {
            Debug.Log("No hay suficientes semillas.");
        }
    }

    void ActualizarTexto(int puntos)
    {
        textoPuntos.text = puntos.ToString();
    }
}