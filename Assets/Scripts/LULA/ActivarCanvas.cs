using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCanvas : MonoBehaviour
{
    [Tooltip("El GameObject que se activará. Arrastra tu Canvas aquí desde la jerarquía.")]
    public GameObject objectToActivate;

    [Tooltip("El tiempo en segundos que el script esperará antes de activar el objeto.")]
    public float delayTime = 5.0f;

    void Start()
    {
        // Al iniciar, nos aseguramos de que el objeto esté inactivo.
        // Puedes desmarcar la casilla de 'activo' en el Inspector.
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }

        // Inicia la corutina que manejará el retardo.
        StartCoroutine(ActivateAfterDelay());
    }

    /// <summary>
    /// Corutina para esperar un tiempo y luego activar el objeto.
    /// </summary>
    IEnumerator ActivateAfterDelay()
    {
        // Espera la cantidad de segundos especificada en 'delayTime'.
        yield return new WaitForSeconds(delayTime);

        // Si el objeto aún existe, lo activa.
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
