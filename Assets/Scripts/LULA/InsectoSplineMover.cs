using UnityEngine;
using System.Collections;
public class InsectoSplineMover : MonoBehaviour
{
    public float tiempoVisible = 3f;    // Tiempo que el objeto estará visible
    public float tiempoInvisible = 2f;  // Tiempo que estará oculto
    private Renderer[] renderers;       // Para mostrar/ocultar visualmente
    private Collider[] colliders;       // Para desactivar colisiones si querés

    void Start()
    {
        // Buscamos todos los renderers y colliders del objeto y sus hijos
        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();

        // Arrancamos la rutina para alternar visibilidad
        StartCoroutine(ControlarAparicion());
    }

    IEnumerator ControlarAparicion()
    {
        while (true)
        {
            // Mostrar
            SetEstado(true);
            yield return new WaitForSeconds(tiempoVisible);

            // Ocultar
            SetEstado(false);
            yield return new WaitForSeconds(tiempoInvisible);
        }
    }

    // Activa o desactiva renderers y colliders
    void SetEstado(bool estado)
    {
        foreach (var r in renderers)
            r.enabled = estado;

        foreach (var c in colliders)
            c.enabled = estado;
    }
}