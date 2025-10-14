using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonInicio : MonoBehaviour
{
    public ApagarCartel apagarCartel;
    public ResetCompras resetCompras;
   private Scene EscenaActual;

    public void IniciarYResetear()
    {
        if (apagarCartel != null)
            apagarCartel.ComenzarJuego();

        if (resetCompras != null)
            resetCompras.ResetearSoloMacetas();

        Debug.Log("Juego iniciado y macetas reseteadas");
    }

    public void RegistrarInicioInvernadero(string idinvernadero)
    {
        EscenaActual = SceneManager.GetActiveScene();

        CustomEvent Datos = new CustomEvent("Comenzar_Nivel")
       {

            { "Nombre_Invernadero", EscenaActual.name },
           

       };

        AnalyticsService.Instance.RecordEvent(Datos);
        AnalyticsService.Instance.Flush();

    }
}