using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorNivelesPetalos : MonoBehaviour
{
    [Header("Condiciones de nivel")]
    public int petalosNecesarios;
    public string nombreEscenaSiguiente;

    [Header("Transición")]
    public float delayCambioEscena = 2f; // ⏱ Tiempo de espera en segundos

    private bool yaCambio = false; // Para evitar múltiples llamados

    private void Update()
    {
        if (!yaCambio && ContadorPetalo.instancia != null &&
            ContadorPetalo.instancia.CantidadPetalos() >= petalosNecesarios)
        {
            yaCambio = true;
            StartCoroutine(CambiarDeNivelConDelay());
        }
    }

    private IEnumerator CambiarDeNivelConDelay()
    {
        Debug.Log("🌸 Recolectaste los pétalos necesarios. Cambio de escena en " + delayCambioEscena + "s...");
        yield return new WaitForSeconds(delayCambioEscena);
        SceneManager.LoadScene(nombreEscenaSiguiente);
    }
}
