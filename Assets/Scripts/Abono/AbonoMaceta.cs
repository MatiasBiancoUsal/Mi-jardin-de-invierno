using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class AbonoMaceta : MonoBehaviour
{
    public GameObject abonoAnimado; // El objeto hijo con animación de abono
    public TMP_Text contadorAbonoTexto; // Texto visible del contador
    public int abonoNecesario = 2;

    private int contador = 0;
    private bool abonoCompletado = false;

    void Start()
    {
        if (abonoAnimado != null) abonoAnimado.SetActive(false);
        if (contadorAbonoTexto != null) contadorAbonoTexto.gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        if (ModoAbono.activo)
        {
            Abonar();
        }
    }

    public void Activar()
    {
        if (contadorAbonoTexto != null)
            contadorAbonoTexto.gameObject.SetActive(true);
    }

    public void Abonar()
    {
        if (abonoCompletado) return;

        if (abonoAnimado != null)
        {
            abonoAnimado.SetActive(true);
            Animator anim = abonoAnimado.GetComponent<Animator>();
            if (anim != null)
                anim.SetTrigger("Abonar");

            Invoke(nameof(DesactivarAbono), 2f); // Ajustá el tiempo según tu animación
        }

        contador++;
        ActualizarTexto();

        if (contador >= abonoNecesario)
        {
            abonoCompletado = true;
            Debug.Log("Abono completo en maceta.");
        }
    }

    void DesactivarAbono()
    {
        if (abonoAnimado != null)
            abonoAnimado.SetActive(false);
    }

    void ActualizarTexto()
    {
        if (contadorAbonoTexto != null)
            contadorAbonoTexto.text = $"{contador}/{abonoNecesario}";
    }
}
