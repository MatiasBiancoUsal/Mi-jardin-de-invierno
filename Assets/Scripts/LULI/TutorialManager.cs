using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [System.Serializable]
    public class PasoTutorial
    {
        public GameObject cartel;      // El panel/cartel del paso
        public string accionEsperada;  // Nombre de la acción que espera (ej: "regar", "plantar", "abrirTienda")
    }

    public List<PasoTutorial> pasos;   // Lista de pasos del tutorial
    private int pasoActual = 0;

    private bool esperandoAccion = false;

    void Start()
    {
        // Desactivamos todos los carteles
        foreach (var paso in pasos)
            paso.cartel.SetActive(false);

        // Mostramos el primer cartel
        MostrarPaso(pasoActual);
    }

    void MostrarPaso(int index)
    {
        if (index < pasos.Count)
        {
            pasos[index].cartel.SetActive(true);
            esperandoAccion = false;
        }
        else
        {
            Debug.Log("Tutorial terminado");
        }
    }

    // Llamado por el botón "Cerrar" de cada cartel
    public void CerrarCartel()
    {
        if (pasoActual < pasos.Count)
        {
            pasos[pasoActual].cartel.SetActive(false);
            esperandoAccion = true; // Ahora esperamos la acción del jugador
        }
    }

    // Este método lo llaman otras partes del juego cuando se hace una acción
    public void RegistrarAccion(string accion)
    {
        if (esperandoAccion && pasoActual < pasos.Count)
        {
            if (accion == pasos[pasoActual].accionEsperada)
            {
                pasoActual++;
                MostrarPaso(pasoActual);
            }
        }
    }
}
