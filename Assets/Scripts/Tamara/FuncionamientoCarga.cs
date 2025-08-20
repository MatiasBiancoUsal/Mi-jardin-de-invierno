using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Lula;

public class FuncionamientoCarga : MonoBehaviour
{
    [Header("UI")]
    public Slider barraSol;
    public GameObject panelBarra;

    private Planta plantaSeleccionada;

    void Start()
    {
        panelBarra.SetActive(false);
        barraSol.minValue = 0f;
        barraSol.value = 0f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Planta planta = hit.collider.GetComponentInParent<Planta>();
                if (planta != null)
                {
                    SeleccionarPlanta(planta);
                }
                else
                {
                    DeseleccionarPlanta();
                }
            }
            else
            {
                DeseleccionarPlanta();
            }
        }

        if (plantaSeleccionada == null) return;

        barraSol.maxValue = plantaSeleccionada.solMaximo;
        barraSol.value = plantaSeleccionada.Sol;
    }

    public void SeleccionarPlanta(Planta planta)
    {
        plantaSeleccionada = planta;
        panelBarra.SetActive(true);
    }

    public void DeseleccionarPlanta()
    {
        plantaSeleccionada = null;
        panelBarra.SetActive(false);
    }

    // Los métodos OnTriggerStay y OnTriggerExit se han eliminado
    // porque ya no son necesarios para esta clase.
}