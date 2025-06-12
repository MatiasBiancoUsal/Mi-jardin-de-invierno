using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesTienda : MonoBehaviour
{
    [Tooltip("Lista de GameObjects que representan las páginas del libro")]
    public GameObject[] paginas;

    [Tooltip("Índice de la página que empieza activa (0 = primera página)")]
    public int paginaActual = 0;

    void Start()
    {
        MostrarPagina(paginaActual);
    }

    // Mostrar solo la página en índice dado
    public void MostrarPagina(int index)
    {
        if (paginas == null || paginas.Length == 0)
        {
            Debug.LogWarning("No hay páginas asignadas.");
            return;
        }

        if (index < 0 || index >= paginas.Length)
        {
            Debug.LogWarning("Índice de página fuera de rango: " + index);
            return;
        }

        // Apagar todas las páginas excepto la actual
        for (int i = 0; i < paginas.Length; i++)
        {
            paginas[i].SetActive(i == index);
        }

        paginaActual = index;
    }

    // Método para botón flecha derecha
    public void SiguientePagina()
    {
        int siguiente = paginaActual + 1;
        if (siguiente >= paginas.Length)
        {
            siguiente = paginas.Length - 1; // O si querés que no avance más
        }
        MostrarPagina(siguiente);
    }

    // Método para botón flecha izquierda
    public void PaginaAnterior()
    {
        int anterior = paginaActual - 1;
        if (anterior < 0)
        {
            anterior = 0; // O si querés que no retroceda más
        }
        MostrarPagina(anterior);
    }
}
