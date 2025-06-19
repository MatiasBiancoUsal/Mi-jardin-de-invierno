using UnityEngine;

public class MostrarMaceta : MonoBehaviour
{
    public GameObject maceta;

    void Start()
    {
        if (EstadoObjetosEscena.mostrarMacetaEnInvernadero && maceta != null)
        {
            maceta.SetActive(true);
        }
        else
        {
            maceta.SetActive(false);
        }
    }
}