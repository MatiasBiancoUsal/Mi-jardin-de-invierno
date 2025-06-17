using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorPlantas : MonoBehaviour
{
    public LayerMask capaPlantas;
    public LayerMask capaEstantes;

    private PlantaSeleccionable plantaSeleccionada;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Clic derecho
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Seleccionar planta
            if (Physics.Raycast(ray, out hit, 100f, capaPlantas))
            {
                SeleccionarPlanta(hit.collider.GetComponent<PlantaSeleccionable>());
            }
            // Colocar planta en estante
            else if (Physics.Raycast(ray, out hit, 100f, capaEstantes))
            {
                Estante estante = hit.collider.GetComponent<Estante>();
                if (plantaSeleccionada != null && estante != null)
                {
                    Transform puntoDisponible = estante.ObtenerPuntoDisponible();

                    if (puntoDisponible != null)
                    {
                        plantaSeleccionada.MoverA(puntoDisponible, estante);
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
}
