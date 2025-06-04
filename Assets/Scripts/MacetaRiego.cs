using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MacetaRiego : MonoBehaviour
{
    public GameObject regaderaAnimada;
    public GameObject semilla;
    public TextMeshProUGUI contadorTexto;
    public GameObject cartelSeleccionado;  // Asigná en el Inspector el cartelito que aparecerá al seleccionar

    private int contadorAgua = 0;
    private bool semillaActiva = false;

    void Start()
    {
        if (semilla != null) semilla.SetActive(false);
        if (regaderaAnimada != null) regaderaAnimada.SetActive(false);
        if (cartelSeleccionado != null) cartelSeleccionado.SetActive(false);

        ActualizarTexto();
    }

    void OnMouseDown()
    {
        // Deseleccionar la maceta anterior (si existe y no es esta)
        if (NewRegadera.macetaSeleccionada != null && NewRegadera.macetaSeleccionada != this)
        {
            NewRegadera.macetaSeleccionada.ActivarCartel(false);
        }

        // Seleccionamos esta maceta
        NewRegadera.macetaSeleccionada = this;
        Debug.Log("Maceta seleccionada");

        // Activamos su cartelito
        ActivarCartel(true);
    }

    public void Regar()
    {
        if (semillaActiva) return;

        if (regaderaAnimada != null)
        {
            regaderaAnimada.SetActive(true);
            Animator anim = regaderaAnimada.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("Regar");
            }

            // Desactivar después de X segundos (duración de la animación)
            Invoke(nameof(DesactivarRegadera), 2.5f); // Ajustá este tiempo según dure tu animación
        }

        contadorAgua++;
        ActualizarTexto();

        if (contadorAgua >= 3)
        {
            ActivarSemilla();
        }
    }

    void DesactivarRegadera()
    {
        if (regaderaAnimada != null)
        {
            regaderaAnimada.SetActive(false);
        }
    }

    void ActivarSemilla()
    {
        if (semilla != null)
        {
            semilla.SetActive(true);
            semillaActiva = true;
            contadorAgua = 0;
            ActualizarTexto();

            Animator anim = semilla.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetBool("Activo", true);
            }
        }
    }

    public void NotificarSemillaRecogida()
    {
        semillaActiva = false;
        contadorAgua = 0;
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        if (contadorTexto != null)
            contadorTexto.text = "Agua: " + contadorAgua + "/3";
    }

    // Este método enciende/apaga el cartel de selección según el parámetro
    public void ActivarCartel(bool activo)
    {
        if (cartelSeleccionado != null)
            cartelSeleccionado.SetActive(activo);
    }
}
