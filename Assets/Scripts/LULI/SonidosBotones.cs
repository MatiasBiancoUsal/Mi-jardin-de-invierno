using UnityEngine;

public class SonidosBotones : MonoBehaviour
{
    public void SonidoRegar()
    {
        AudioManager.instance.ReproducirSonido("regar");
        var tutorial = Object.FindFirstObjectByType<TutorialManager>();
        if (tutorial != null) tutorial.RegistrarAccion("regar");
    }

    public void SonidoAbonar()
    {
        AudioManager.instance.ReproducirSonido("abonar");
        var tutorial = Object.FindFirstObjectByType<TutorialManager>();
        if (tutorial != null) tutorial.RegistrarAccion("abonar");
    }

    public void SonidoPlantar()
    {
        AudioManager.instance.ReproducirSonido("plantar");
        var tutorial = Object.FindFirstObjectByType<TutorialManager>();
        if (tutorial != null) tutorial.RegistrarAccion("plantar");
    }
    
    public void SonidoAbrirTienda()
    {
        AudioManager.instance.ReproducirSonido("abrirTienda");
        var tutorial = Object.FindFirstObjectByType<TutorialManager>();
        if (tutorial != null) tutorial.RegistrarAccion("abrirTienda");
    }
}
