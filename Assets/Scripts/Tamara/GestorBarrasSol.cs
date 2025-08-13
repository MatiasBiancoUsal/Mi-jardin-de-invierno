using UnityEngine;
using System.Collections.Generic;

public class GestorBarrasSol : MonoBehaviour
{
    public static GestorBarrasSol instancia;

    // Lista para todas las barras registradas
    private List<BarraSolUI> barrasRegistradas = new List<BarraSolUI>();

    private void Awake()
    {
        instancia = this;
    }

    // Método para registrar barras nuevas
    public void RegistrarBarra(BarraSolUI barra)
    {
        if (!barrasRegistradas.Contains(barra))
            barrasRegistradas.Add(barra);
    }

    public void MostrarSolo(BarraSolUI barraMostrada)
    {
        foreach (BarraSolUI barra in barrasRegistradas)
        {
            barra.gameObject.SetActive(false);
        }

        if (barraMostrada != null)
            barraMostrada.gameObject.SetActive(true);
    }

    public void OcultarTodas()
    {
        foreach (BarraSolUI barra in barrasRegistradas)
        {
            barra.gameObject.SetActive(false);
        }
    }
}

