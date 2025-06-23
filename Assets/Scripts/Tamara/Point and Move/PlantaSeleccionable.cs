using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaSeleccionable : MonoBehaviour
{
    private Renderer rend;
    private Color colorOriginal;

    private Transform puntoActual = null;
    private Estante estanteActual = null;
    private PuntoDePlantado puntoDePisoActual = null;

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

    public void MoverA(Transform nuevoPunto, Estante nuevoEstante = null, PuntoDePlantado nuevoPuntoDePiso = null)
    {
        // liberar estante anterior si había
        if (estanteActual != null && puntoActual != null)
        {
            estanteActual.LiberarPunto(puntoActual);
        }

        // Liberar punto de piso anterior si había
        if (puntoDePisoActual != null)
        {
            puntoDePisoActual.ocupado = false;
        }

        //Mover planta
        transform.position = nuevoPunto.position;

        // Guardar nueva ubicación
        puntoActual = nuevoPunto;
        estanteActual = nuevoEstante;
        puntoDePisoActual = nuevoPuntoDePiso;

        Deseleccionar();
    }
}