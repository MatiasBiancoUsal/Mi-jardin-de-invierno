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

    void ActualizarTexto()
    {
        if (textoPuntos != null)
        {
            textoPuntos.text = puntos.ToString();
        }
    }
}

