using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorNivelesPetalos : MonoBehaviour
{
    [Header("Condiciones de nivel")]
    public int petalosNecesarios;
    public string nombreEscenaSiguiente;

    private void Update()
    {
        if (ContadorPetalo.instancia != null &&
            ContadorPetalo.instancia.CantidadPetalos() >= petalosNecesarios)
        {
            CambiarDeNivel();
        }
    }

    void CambiarDeNivel()
    {
        Debug.Log($"✅ Se recolectaron {petalosNecesarios} pétalos. Cargando: {nombreEscenaSiguiente}");
        SceneManager.LoadScene(nombreEscenaSiguiente);
    }
}
