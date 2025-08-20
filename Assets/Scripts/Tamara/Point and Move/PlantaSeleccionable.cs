using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Lula; // Es necesario para acceder a la clase Planta

public class PlantaSeleccionable : MonoBehaviour
{
    [Header("Efecto de selección")]
    [SerializeField] private GameObject halo; // arrastrar aquí el Quad/Sphere hijo con el material emissive

    private Renderer rend;
    private Color colorOriginal;
    private bool isSelected = false;

    // Tu estado de posicionamiento
    private Transform puntoActual = null;
    private Estante estanteActual = null;
    private PuntoDePlantado puntoDePisoActual = null;

    // Cambiado a tipo Planta
    private Planta planta;

    void Awake()
    {
        // Busca Renderer en este objeto o en hijos
        rend = GetComponent<Renderer>();
        if (rend == null) rend = GetComponentInChildren<Renderer>();

        if (rend != null)
        {
            // Instanciamos el material para no modificar sharedMaterial de otras plantas
            rend.material = new Material(rend.material);
            colorOriginal = rend.material.color;
        }
        else
        {
            Debug.LogWarning($"[{name}] No se encontró Renderer en este objeto ni en sus hijos.");
        }

        if (halo != null) halo.SetActive(false); // asegurar que empieza desactivado

        // Ahora busca y referencia el script Planta
        planta = GetComponent<Planta>();
    }

    // Opcional: seleccionar con clic (necesita Collider)
    void OnMouseDown()
    {
        // Si ya está seleccionada, no hacer nada (mantener halo)
        if (isSelected)
            return;

        Seleccionar();
    }

    public void Seleccionar()
    {
        isSelected = true;
        if (rend != null) rend.material.color = Color.green;
        if (halo != null) halo.SetActive(true);

        FuncionamientoCarga instanciaCarga = FindFirstObjectByType<FuncionamientoCarga>();
        if (instanciaCarga != null)
            // Llama al método SeleccionarPlanta con el objeto 'planta' de tipo Planta
            instanciaCarga.SeleccionarPlanta(planta);

        Debug.Log(name + " seleccionada");
    }


    public void Deseleccionar()
    {
        isSelected = false;
        if (rend != null) rend.material.color = Color.white;
        if (halo != null) halo.SetActive(false);

        FuncionamientoCarga instanciaCarga = FindFirstObjectByType<FuncionamientoCarga>();
        if (instanciaCarga != null)
            instanciaCarga.DeseleccionarPlanta();
    }


    public void ToggleSeleccion()
    {
        if (isSelected) Deseleccionar(); else Seleccionar();
    }

    // Tu método MoverA (copié el tuyo y lo dejé igual)
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