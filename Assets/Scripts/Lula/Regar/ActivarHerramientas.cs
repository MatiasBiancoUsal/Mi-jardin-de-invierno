using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Lula;
using UnityEngine;

public class ActivarHerramientas : MonoBehaviour
{
    public GameObject Regadera;
    public GameObject Abono;




    // Update is called once per frame
    void OnMouseDown()
    {
        if (SistemaDePlantas.instancia.ModoRiego)
        {
            Regadera.SetActive(true);
        }

       else
        {
            Regadera.SetActive(false);
        }


        if (SistemaDePlantas.instancia.ModoAbono)
        {
            Abono.SetActive(true);
        }

        else
        {
            Abono.SetActive(false);
        }
    }
}
