using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Gestiona la puntuación y la visualización de los puntos en la interfaz de usuario.
/// </summary>
public class Contador : MonoBehaviour
{
    // Variables públicas
    public int puntos = 0;

    // Referencia al componente de texto UI para mostrar la puntuación.
    // Se debe arrastrar desde el Inspector de Unity.
    public TextMeshProUGUI textoPuntos;

    // MÉTODOS PÚBLICOS

    /// <summary>
    /// Suma un punto a la puntuación actual y actualiza el texto en la UI.
    /// </summary>
    public void SumarPunto()
    {
        puntos++;
        ActualizarTexto();
    }

    /// <summary>
    /// Gasta 2 "semillas" (puntos) si la puntuación es suficiente.
    /// Si no hay suficientes puntos, muestra un mensaje de depuración.
    /// </summary>
    public void GastarSemillas()
    {
        if (puntos >= 2)
        {
            puntos -= 2;
            ActualizarTexto();
        }
        else
        {
            // Muestra un mensaje en la consola de Unity.
            Debug.Log("No hay suficientes semillas.");
        }
    }

    // MÉTODOS PRIVADOS

    /// <summary>
    /// Actualiza el texto de la UI con el valor actual de los puntos.
    /// Se llama automáticamente después de sumar o restar puntos.
    /// </summary>
    void ActualizarTexto()
    {
        // Asegúrate de que la referencia al texto no sea nula antes de intentar actualizarla.
        if (textoPuntos != null)
        {
            // Convierte el valor entero de 'puntos' a una cadena de texto.
            textoPuntos.text = puntos.ToString();
        }
    }
}