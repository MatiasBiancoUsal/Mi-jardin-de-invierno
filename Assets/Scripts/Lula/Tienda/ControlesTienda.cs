using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesTienda : MonoBehaviour
{
    [Tooltip("Lista de GameObjects que representan las p�ginas del libro")]
    public GameObject[] paginas;

    [Tooltip("�ndice de la p�gina que empieza activa (0 = primera p�gina)")]
    public int paginaActual = 0;

    void Start()
    {
        MostrarPagina(paginaActual);
    }

    // Mostrar solo la p�gina en �ndice dado
    public void MostrarPagina(int index)
    {
        if (paginas == null || paginas.Length == 0)
        {
            Debug.LogWarning("No hay p�ginas asignadas.");
            return;
        }

        if (index < 0 || index >= paginas.Length)
        {
            Debug.LogWarning("�ndice de p�gina fuera de rango: " + index);
            return;
        }

        // Apagar todas las p�ginas excepto la actual
        for (int i = 0; i < paginas.Length; i++)
        {
            paginas[i].SetActive(i == index);
        }

        paginaActual = index;
    }

    // M�todo para bot�n flecha derecha
    public void SiguientePagina()
    {
        int siguiente = paginaActual + 1;
        if (siguiente >= paginas.Length)
        {
            siguiente = paginas.Length - 1; // O si quer�s que no avance m�s
        }
        MostrarPagina(siguiente);
    }

    // M�todo para bot�n flecha izquierda
    public void PaginaAnterior()
    {
        int anterior = paginaActual - 1;
        if (anterior < 0)
        {
            anterior = 0; // O si quer�s que no retroceda m�s
        }
        MostrarPagina(anterior);
    }
}
