using UnityEngine;
using UnityEngine.SceneManagement;

public class OmitirIntro : MonoBehaviour
{
    [Header("Nombre de la escena a cargar")]
    public string nombreEscenaDestino;

    // Método que se ejecuta al tocar el botón
    public void Omitir()
    {
        SceneManager.LoadScene(nombreEscenaDestino);
    }
}