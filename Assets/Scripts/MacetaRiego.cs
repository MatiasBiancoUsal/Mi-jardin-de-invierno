using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MacetaRiego : MonoBehaviour
{
    public GameObject regaderaAnimada;
    public GameObject semilla;
    public TextMeshProUGUI contadorAgua; // Cambiado el nombre acá
    public GameObject cartelSeleccionado;
    public int aguaNecesaria = 3;

    private int contador = 0;
    private bool semillaActiva = false;

    void Start()
    {
        if (semilla != null) semilla.SetActive(false);
        if (regaderaAnimada != null) regaderaAnimada.SetActive(false);
        if (cartelSeleccionado != null) cartelSeleccionado.SetActive(false);
        if (contadorAgua != null) contadorAgua.gameObject.SetActive(false);

        ActualizarTexto();
    }

    void OnMouseDown()
    {
        if (NewRegadera.macetaSeleccionada != null && NewRegadera.macetaSeleccionada != this)
        {
            NewRegadera.macetaSeleccionada.ActivarCartel(false);
            NewRegadera.macetaSeleccionada.ActivarContador(false);
        }

        NewRegadera.macetaSeleccionada = this;
        Debug.Log("Maceta seleccionada");

        ActivarCartel(true);
        ActivarContador(true);
        ActualizarTexto();
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
            Invoke(nameof(DesactivarRegadera), 2.5f);
        }

        contador++;
        ActualizarTexto();

        if (contador >= aguaNecesaria)
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
            contador = 0;
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
        contador = 0;
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        if (contadorAgua != null)
            contadorAgua.text = $"Agua: {contador}/{aguaNecesaria}";
    }

    public void ActivarCartel(bool activo)
    {
        if (cartelSeleccionado != null)
            cartelSeleccionado.SetActive(activo);
    }

    public void ActivarContador(bool activo)
    {
        if (contadorAgua != null)
            contadorAgua.gameObject.SetActive(activo);
    }
}
