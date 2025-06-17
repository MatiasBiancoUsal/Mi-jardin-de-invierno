using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaSeleccionable : MonoBehaviour
{
    private Renderer rend;
    private Color colorOriginal;

    private Transform puntoActual = null;
    private Estante estanteActual = null;

    void Start()
    {
        rend = GetComponent<Renderer>();
        colorOriginal = rend.material.color;
    }

    public void Seleccionar()
    {
        rend.material.color = Color.green;
    }

    public void Deseleccionar()
    {
        rend.material.color = colorOriginal;
    }

    public void MoverA(Transform nuevoPunto, Estante nuevoEstante)
    {
        // Liberar punto anterior si había
        if (estanteActual != null && puntoActual != null)
        {
            estanteActual.LiberarPunto(puntoActual);
        }

        // Mover y asignar
        transform.position = nuevoPunto.position;
        puntoActual = nuevoPunto;
        estanteActual = nuevoEstante;
        Deseleccionar();
    }
}
