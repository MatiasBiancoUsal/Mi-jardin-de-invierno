using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorDeMaceta : MonoBehaviour
{
    public GameObject maceta;

    void Start()
    {
        if (EstadoObjetosEscena.mostrarMacetaEnInvernadero)
        {
            maceta.SetActive(true);
        }
        else
        {
            maceta.SetActive(false); // Asegura que este oculta si no fue activada
        }
    }
}