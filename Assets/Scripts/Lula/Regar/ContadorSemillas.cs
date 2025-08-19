using TMPro;
using UnityEngine;

public class ContadorSemillas : MonoBehaviour
{
    public static ContadorSemillas instancia;

    [Header("UI")]
    public TMP_Text textoContadorSemillas;

    private int contadorSemillas = 100; // Arranca en 100 solo una vez

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Se mantiene al cambiar pantallas/escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ActualizarTextoUI();
    }

    public void SumarSemilla(int cantidad = 1)
    {
        contadorSemillas += cantidad;
        ActualizarTextoUI();
    }

    public void GastarSemillas(int cantidad)
    {
        if (contadorSemillas >= cantidad)
        {
            contadorSemillas -= cantidad;
            ActualizarTextoUI();
            Debug.Log($"Compra realizada. Quedan {contadorSemillas}");
        }
        else
        {
            Debug.Log("No hay suficientes semillas.");
        }
    }

    private void ActualizarTextoUI()
    {
        if (textoContadorSemillas != null)
        {
            textoContadorSemillas.text = contadorSemillas.ToString();
        }
    }

    public int GetSemillas()
    {
        return contadorSemillas;
    }
}