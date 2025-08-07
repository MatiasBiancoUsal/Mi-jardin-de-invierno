using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Lula;
using UnityEngine;

public class ActivarHerramientas : MonoBehaviour
{
    public GameObject Abono;

    [Header("Referencias")]
    public GameObject Regadera;   
    public Planta planta;          

    [Header("Configuración")]
    public float duracionAnimacion = 2.6f;




    // Update is called once per frame
    void OnMouseDown()
    {
        if (SistemaDePlantas.instancia.ModoRiego && Regadera != null && planta != null)
        {
            StartCoroutine(RegarAutomaticamente());
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

    private IEnumerator RegarAutomaticamente()
    {
     
        Regadera.SetActive(true);

        
        yield return new WaitForSeconds(duracionAnimacion);

 
        planta.SubirAgua();

     
        Regadera.SetActive(false);
    }
}
