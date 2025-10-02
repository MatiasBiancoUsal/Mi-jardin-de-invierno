using UnityEngine;

public class BotonInicio : MonoBehaviour
{
    public ApagarCartel apagarCartel;
    public ResetCompras resetCompras;

    public void IniciarYResetear()
    {
        if (apagarCartel != null)
            apagarCartel.ComenzarJuego();

        if (resetCompras != null)
            resetCompras.ResetearSoloMacetas();

        Debug.Log("Juego iniciado y macetas reseteadas");
    }
}