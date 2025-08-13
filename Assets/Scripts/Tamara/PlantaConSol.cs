using UnityEngine;

public class PlantaConSol : MonoBehaviour
{
    public float Sol;
    public float solMaximo = 100f;

    [SerializeField] private BarraSolUI barraUI;

    void Awake()
    {
        if (barraUI == null) barraUI = GetComponentInChildren<BarraSolUI>(true);
    }

    public BarraSolUI ObtenerBarra()
    {
        return barraUI;
    }
}


