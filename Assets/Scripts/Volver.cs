using UnityEngine;
using UnityEngine.SceneManagement;

public class Volver : MonoBehaviour
{
    public void VolverAEscenaPrincipal()
    {
        SceneManager.LoadScene("PantallaInicio"); // ← Usa el nombre real de tu escena
    }

    public void MostrarControles()
    {
        SceneManager.LoadScene("Plantilla de Controles"); // ← Usa el nombre real de tu escena
    }

    public void PrimerNivel()
    {
        SceneManager.LoadScene("Invernadero"); // ← Usa el nombre real de tu escena
    }

}
