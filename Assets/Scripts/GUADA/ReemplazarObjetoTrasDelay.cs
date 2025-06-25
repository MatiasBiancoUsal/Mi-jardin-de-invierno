using UnityEngine;
using System.Collections;

public class ReemplazarObjetoTrasDelay : MonoBehaviour
{
    public GameObject objetoNuevo;  
    public string nombreObjeto;     
    public float tiempoEspera = 14f;

    void Start()
    {
        //la planta crecida, mostrar directamente el objeto nuevo
        if (PlayerPrefs.GetInt(nombreObjeto + "_Crecido", 0) == 1)
        {
            if (objetoNuevo != null)
                objetoNuevo.SetActive(true);

            gameObject.SetActive(false); //oculta la maceta original, la vacia
        }
        else
        {
            StartCoroutine(EsperarYReemplazar());
        }
    }

    IEnumerator EsperarYReemplazar()
    {
        yield return new WaitForSeconds(tiempoEspera);

        //guarda la planta crecida
        PlayerPrefs.SetInt(nombreObjeto + "_Crecido", 1);
        PlayerPrefs.Save();

        //reemplaza
        if (objetoNuevo != null)
            objetoNuevo.SetActive(true);

        gameObject.SetActive(false);
    }
}