using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SincronizarSemillas : MonoBehaviour
{
    public TMP_Text textoContadorSemillas;

    void Start()
    {
        ActualizarTexto(ContadorSemillas.instancia.contadorSemillas);
        ContadorSemillas.instancia.cambioSemillas += ActualizarTexto;
    }

    private void ActualizarTexto(int valor)
    {
        textoContadorSemillas.text = valor.ToString();
    }

    private void OnDestroy()
    {
        ContadorSemillas.instancia.cambioSemillas -= ActualizarTexto;
    }

}
