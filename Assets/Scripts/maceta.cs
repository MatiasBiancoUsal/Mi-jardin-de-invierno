using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class maceta : MonoBehaviour
{
    public GameObject semilla;               // Asigná el objeto de la semilla
    public float tiempoEspera = 1f;          // Tiempo en segundos antes de activar
    public TextMeshProUGUI contadorTexto;    // Asigná el objeto de texto
    private int contadorClicks = 0;
    private bool yaActivado = false;

    void Start()
    {
        ActualizarTexto();
    }

    void OnMouseDown()
    {
        if (yaActivado) return;

        contadorClicks++;

        ActualizarTexto();

        if (contadorClicks == 3)
        {
            StartCoroutine(ActivarSemillaConDelay());
        }
    }

    void ActualizarTexto()
    {
        if (contadorTexto != null)
        {
            contadorTexto.text = contadorClicks + "/3";
        }
    }

    IEnumerator ActivarSemillaConDelay()
    {
        yaActivado = true;
        yield return new WaitForSeconds(tiempoEspera);
        semilla.SetActive(true);
    }
}
