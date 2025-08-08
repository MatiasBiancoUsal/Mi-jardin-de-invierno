using UnityEngine;
using UnityEngine.UI;

public class BarraSolUI : MonoBehaviour
{
    [SerializeField] private Slider barraSol; // Asigná el Slider desde el inspector
    [SerializeField] private Canvas canvasUI; // El Canvas hijo de la planta
    private PlantaConSol planta;

    private void Awake()
    {
        planta = GetComponentInParent<PlantaConSol>();
        Ocultar();
    }

    private void Update()
    {
        if (planta != null)
        {
            barraSol.value = planta.Sol / planta.solMaximo;
        }
    }

    public void Mostrar()
    {
        canvasUI.enabled = true;
    }

    public void Ocultar()
    {
        canvasUI.enabled = false;
    }
}
