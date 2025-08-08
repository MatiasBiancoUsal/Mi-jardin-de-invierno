using UnityEngine;

public class PlantaConSol : MonoBehaviour
{
    public float Sol = 0;
    public float solMaximo = 100;

    private static BarraSolUI barraActiva;

    [SerializeField] private BarraSolUI barraUI; // Arrastrás el script de la barra desde el inspector

    private void OnMouseDown()
    {
        if (barraActiva != null && barraActiva != barraUI)
        {
            barraActiva.Ocultar();
        }

        barraUI.Mostrar();
        barraActiva = barraUI;
    }
}
