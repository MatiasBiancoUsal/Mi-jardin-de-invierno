using UnityEngine;
using UnityEngine.EventSystems;

public class BarraSelectPlanta : MonoBehaviour
{
    private static BarraSolUI barraActiva;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                PlantaConSol planta = hit.collider.GetComponentInParent<PlantaConSol>();
                if (planta != null)
                {
                    BarraSolUI nuevaBarra = planta.GetComponentInChildren<BarraSolUI>();

                    if (nuevaBarra != null) //Solo si existe la barra
                    {
                        if (barraActiva != null && barraActiva != nuevaBarra)
                            barraActiva.Ocultar();

                        barraActiva = nuevaBarra;
                        barraActiva.Mostrar();
                    }
                }
                else if (barraActiva != null)
                {
                    barraActiva.Ocultar();
                    barraActiva = null;
                }
            }
        }
    }
}
