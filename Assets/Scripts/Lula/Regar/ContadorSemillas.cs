using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class ContadorSemillas : MonoBehaviour
{
    public static ContadorSemillas instancia;

    [Header("UI (pueden ser varios textos en tienda e invernadero)")]
    public List<TMP_Text> textosContador = new List<TMP_Text>();

    private int contadorSemillas = 100;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Esto mantiene el contador aunque cambies de escena
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
        foreach (TMP_Text texto in textosContador)
        {
            if (texto != null)
                texto.text = contadorSemillas.ToString();
        }
    }

    public int GetSemillas()
    {
        return contadorSemillas;
    }
}