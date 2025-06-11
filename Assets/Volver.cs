using UnityEngine;
using UnityEngine.SceneManagement;

public class Volver : MonoBehaviour
{
    public void VolverAEscenaPrincipal()
    {
        SceneManager.LoadScene("PantallaInicio"); // ← Usa el nombre real de tu escena
    }
}
