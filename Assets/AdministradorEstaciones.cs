using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorEstaciones : MonoBehaviour
{
    public int[] estaciones = new int[4];

    // 0 = invierno
    // 1 = primavera
    // 2 = verano
    // 3 = otoño


    public int estacionActual;


    // APLICAR SINGLETON

    private void Start()
    {
        estacionActual = 0;
    }
    public void CambiarEstacion()
    {
        estacionActual++;

        if(estacionActual >= estaciones.Length)
        {
            estacionActual = 0;
        }

    }

}
