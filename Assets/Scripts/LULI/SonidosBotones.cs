using UnityEngine;

public class SonidosBotones : MonoBehaviour
{
     public void SonidoRegar()
    {
        AudioManager.instance.ReproducirSonido("regar");
    }

    public void SonidoAbonar()
    {
        AudioManager.instance.ReproducirSonido("abonar");
    }

    public void SonidoPlantar()
    {
        AudioManager.instance.ReproducirSonido("plantar");
    }
}

