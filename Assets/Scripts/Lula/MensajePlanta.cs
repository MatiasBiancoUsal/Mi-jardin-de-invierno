using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Lula;

public class MensajePlanta : MonoBehaviour
{
    public TextMeshProUGUI textoMensaje;       // El componente de texto
    public GameObject cartelMensaje;           // El cartel entero (imagen + texto)
    public List<string> frases;                // Lista de frases posibles
    public Planta Planta;

    private bool MostrandoMensaje;

    // Mostrar una frase aleatoria
    public void MostrarMensajeAleatorio()
    {
        string fraseAleatoria = frases[Random.Range(0, frases.Count)];
        textoMensaje.text = fraseAleatoria;
        cartelMensaje.SetActive(true);
        Debug.Log("Mostrando mensaje feliz: " + fraseAleatoria);
        MostrandoMensaje = true;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit)) return;
            if (hit.collider.gameObject != gameObject) return;

            if (MostrandoMensaje)
            {
                OcultarMensaje();
            }
            else if (Planta.TieneFelicidad())
            {
                MostrarMensajeAleatorio();
            }

        }
    }

    // Ocultar el mensaje
    public void OcultarMensaje()
    {
        MostrandoMensaje = false;
        cartelMensaje.SetActive(false);
    }
}
