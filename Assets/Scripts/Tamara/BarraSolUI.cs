using Assets.Scripts.Lula;
using UnityEngine;
using UnityEngine.UI;

public class BarraSolUI : MonoBehaviour
{
    [SerializeField] private Slider barraSol;     // El slider que representa el sol
    private Planta planta;                        // Referencia a la planta

    void Start()
    {
        Ocultar(); // Arranca oculta
    }
    void Awake()
    {
        // Si no arrastraste el slider en el inspector, lo busca automáticamente
        if (barraSol == null)
            barraSol = GetComponentInChildren<Slider>(true);

        // Busca el script Planta en el padre
        planta = GetComponentInParent<Planta>();
    }

    void Update()
    {
        if (planta == null || barraSol == null) return;

        // Configuración del slider
        barraSol.minValue = 0f;
        barraSol.maxValue = (planta.solMaximo <= 0f) ? 1f : planta.solMaximo;
        barraSol.wholeNumbers = false;

        // Actualiza el valor
        barraSol.value = Mathf.Clamp(planta.Sol, 0f, barraSol.maxValue);
    }

    public void Mostrar()
    {
        gameObject.SetActive(true);
    }

    public void Ocultar()
    {
        gameObject.SetActive(false);
    }
}
