using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    [Tooltip("Nombre exacto de la escena a cargar")]
    public string nombreEscena;

    public void IrAEscena()
    {
        if (!string.IsNullOrEmpty(nombreEscena))
        {
            SceneManager.LoadScene(nombreEscena);
        }
        else
        {
            Debug.LogWarning("⚠️ No se asignó un nombre de escena en el botón.");
        }
    }
}
