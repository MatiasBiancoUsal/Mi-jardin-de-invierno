using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorNivelesPetalos : MonoBehaviour
{
    [Header("Condiciones de nivel")]
    public int petalosNecesarios;
    public string nombreEscenaSiguiente;

    [Header("Transición")]
    public float delayCambioEscena = 2f;

    public void Start()
    {
        ContadorPetalo.instancia.cambioPetalos += CheckearCambioDeEscena;
    }

    public void OnDestroy()
    {
        ContadorPetalo.instancia.cambioPetalos -= CheckearCambioDeEscena;
    }

    private void CheckearCambioDeEscena()
    {
        if (ContadorPetalo.instancia.CantidadPetalos() >= petalosNecesarios)
        {
            ContadorPetalo.instancia.contadorPetalos = 0;
            var Datos = new CustomEvent("Final_Nivel")
            {

                {"Cantidad_Semillas", ContadorSemillas.instancia.contadorSemillas},
                { "Nombre_Invernadero", SceneManager.GetActiveScene().name },
            };

            AnalyticsService.Instance.RecordEvent(Datos);
            AnalyticsService.Instance.Flush();
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
