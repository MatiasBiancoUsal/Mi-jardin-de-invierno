using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorPlantas : MonoBehaviour
{
    public LayerMask capaPlantas;
    public LayerMask capaEstantes;
    public LayerMask capaPiso;

    private PlantaSeleccionable plantaSeleccionada;
    private PuntoDePlantado[] puntosDePlantado;

    void Start()
    {
        puntosDePlantado = FindObjectsOfType<PuntoDePlantado>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // clic derecho
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Clic en planta
            if (Physics.Raycast(ray, out hit, 100f, capaPlantas))
            {
                SeleccionarPlanta(hit.collider.GetComponent<PlantaSeleccionable>());
            }

            // Clic en estante
            else if (Physics.Raycast(ray, out hit, 100f, capaEstantes))
            {
                Estante estante = hit.collider.GetComponent<Estante>();
                if (plantaSeleccionada != null && estante != null)
                {
                    Transform puntoDisponible = estante.ObtenerPuntoDisponible();

                    if (puntoDisponible != null)
                    {
                        plantaSeleccionada.MoverA(puntoDisponible, estante, null); // acá va el primer caso
                        plantaSeleccionada = null;
                    }
                }
            }

            // Clic en piso
            else if (Physics.Raycast(ray, out hit, 100f, capaPiso))
            {
                if (plantaSeleccionada != null)
                {
                    Transform puntoCercano = BuscarPuntoMasCercano(hit.point);
                    if (puntoCercano != null)
                    {
                        PuntoDePlantado puntoScript = puntoCercano.GetComponent<PuntoDePlantado>();
                        plantaSeleccionada.MoverA(puntoCercano, null, puntoScript); // segundo caso
                        puntoScript.ocupado = true;
                        plantaSeleccionada = null;
                    }
                }
            }
        }
    }

    void SeleccionarPlanta(PlantaSeleccionable nueva)
    {
        if (plantaSeleccionada != null)
            plantaSeleccionada.Deseleccionar();

        plantaSeleccionada = nueva;
        plantaSeleccionada.Seleccionar();
    }

    Transform BuscarPuntoMasCercano(Vector3 posicionClick)
    {
        Transform mejor = null;
        float menorDist = Mathf.Infinity;

        foreach (PuntoDePlantado punto in puntosDePlantado)
        {
            if (!punto.ocupado)
            {
                float dist = Vector3.Distance(posicionClick, punto.transform.position);
                if (dist < menorDist)
                {
                    menorDist = dist;
                    mejor = punto.transform;
                }
            }
        }

        return mejor;
    }
}
