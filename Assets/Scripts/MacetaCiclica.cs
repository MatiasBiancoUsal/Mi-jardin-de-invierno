using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MacetaCiclica : MonoBehaviour
{
    public GameObject semilla;                // Asigná la semilla en el inspector
    public TextMeshProUGUI contadorTexto;     // Texto tipo "1/3"
    public int puntos = 0;

    private int contadorClicks = 0;
    private bool semillaActiva = false;

    void Start()
    {
        if (semilla != null)
            semilla.SetActive(false);  // Empieza desactivada

        ActualizarTexto();
    }

    void OnMouseDown()
    {
        if (semillaActiva) return; // No permitir regar si hay semilla activa

        contadorClicks++;
        ActualizarTexto();

        if (contadorClicks >= 3)
        {
            ActivarSemilla();
        }
    }

    void ActualizarTexto()
    {
        if (contadorTexto != null)
        {
            contadorTexto.text = contadorClicks + "/3";
        }
    }

    void ActivarSemilla()
    {
        if (semilla != null)
        {
            semilla.SetActive(true);
            semillaActiva = true;
            contadorClicks = 0;
            ActualizarTexto();

            // Animación (si tiene)
            Animator anim = semilla.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetBool("Activo", true);
            }
        }
    }

    public void NotificarSemillaDesactivada()
    {
        semillaActiva = false; // Permitir nuevo ciclo de riego
    }
}
