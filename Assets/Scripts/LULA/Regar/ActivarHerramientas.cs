using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Lula;
using UnityEngine;

public class ActivarHerramientas : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject Regadera;
    public GameObject Abono;
    public Planta planta;

    [Header("Configuración")]
    public float duracionAnimacionRiego = 2.6f;
    public float duracionAnimacionAbono = 2.6f;

    void OnMouseDown()
    {
        // Riego automático
        if (SistemaDePlantas.instancia.ModoRiego && Regadera != null && planta != null)
        {
            StartCoroutine(RegarAutomaticamente());
        }

        // Abono automático
        if (SistemaDePlantas.instancia.ModoAbono && Abono != null && planta != null)
        {
            StartCoroutine(AbonarAutomaticamente());
        }

    }

    private IEnumerator RegarAutomaticamente()
    {
        Regadera.SetActive(true);

        yield return new WaitForSeconds(duracionAnimacionRiego);

        planta.EnMantenimiento = true; // Nos aseguramos que acepte el riego
        planta.SubirAgua();

        Regadera.SetActive(false);
    }

    private IEnumerator AbonarAutomaticamente()
    {
        Abono.SetActive(true);

        yield return new WaitForSeconds(duracionAnimacionAbono);

        planta.EnMantenimiento = true; // Nos aseguramos que acepte el abono
        planta.SubirAbono();

        Abono.SetActive(false);
    }
}
