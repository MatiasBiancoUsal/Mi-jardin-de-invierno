using UnityEngine;
using System.Collections;

public class ReemplazarObjetoTrasDelayTutorial : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject objetoNuevo;  
    public float tiempoEspera = 14f; 

    private void Start()
    {
        
        if (objetoNuevo != null)
            objetoNuevo.SetActive(false);

      
        StartCoroutine(EsperarYReemplazar());
    }

    private IEnumerator EsperarYReemplazar()
    {
        yield return new WaitForSeconds(tiempoEspera);

        if (objetoNuevo != null)
            objetoNuevo.SetActive(true);

        gameObject.SetActive(false);

        Debug.Log("(Tutorial) La planta ha crecido temporalmente.");
    }
}
