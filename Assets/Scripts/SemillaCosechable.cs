using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemillaCosechable : MonoBehaviour
{
    private bool yaCosechada = false;
    public MacetaCiclica miMaceta; // Maceta asociada

    void OnMouseDown()
    {
        if (yaCosechada) return;
        yaCosechada = true;

        contador contador = FindObjectOfType<contador>();
        if (contador != null)
        {
            contador.SumarPunto();
        }

        // Avisar a la maceta que ya se recolectó
        if (miMaceta != null)
        {
            miMaceta.NotificarSemillaDesactivada();
        }

        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        yaCosechada = false;
    }
}
