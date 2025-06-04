using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemillaCosechable : MonoBehaviour
{
    private bool yaCosechada = false;
    public MacetaRiego miMaceta; // Referencia a la maceta asociada

    void OnMouseDown()
    {
        if (yaCosechada) return;
        yaCosechada = true;

        contador contador = FindObjectOfType<contador>();
        if (contador != null)
        {
            contador.SumarPunto();
        }

        // Avisar a la maceta que la semilla fue recogida para permitir regar de nuevo
        if (miMaceta != null)
        {
            miMaceta.NotificarSemillaRecogida();
        }

        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        yaCosechada = false;
    }
}
