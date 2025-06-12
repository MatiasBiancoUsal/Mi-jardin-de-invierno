using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MensajePlanta : MonoBehaviour
{
    public TextMeshProUGUI textoMensaje;       // El componente de texto
    public GameObject cartelMensaje;           // El cartel entero (imagen + texto)
    public List<string> frases;                // Lista de frases posibles

    // Mostrar una frase aleatoria
    public void MostrarMensajeAleatorio()
    {
        string fraseAleatoria = frases[Random.Range(0, frases.Count)];
        textoMensaje.text = fraseAleatoria;
        cartelMensaje.SetActive(true);
        Debug.Log("Mostrando mensaje feliz: " + fraseAleatoria);
    }

    // Ocultar el mensaje
    public void OcultarMensaje()
    {
        cartelMensaje.SetActive(false);
    }
}
