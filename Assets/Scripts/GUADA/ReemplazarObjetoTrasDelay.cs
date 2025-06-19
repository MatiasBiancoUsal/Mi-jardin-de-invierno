using UnityEngine;
using System.Collections;

public class ReemplazarObjetoTrasDelay : MonoBehaviour
{
    public GameObject objetoNuevo;  // Objeto que se debe activar
    public float tiempoEspera = 14f; // Tiempo antes del cambio

    void Start()
    {
        StartCoroutine(EsperarYReemplazar());
    }

    IEnumerator EsperarYReemplazar()
    {
        yield return new WaitForSeconds(tiempoEspera);

        // Desactiva este objeto
        gameObject.SetActive(false);

        // Activa el nuevo
        if (objetoNuevo != null)
            objetoNuevo.SetActive(true);
    }
}