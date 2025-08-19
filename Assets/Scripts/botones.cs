using UnityEngine;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    public Button semillas;
    public GameObject panelTienda; //  arrastrá desde el inspector el Canvas/Panel de la tienda

    void Start()
    {

    }

    void Update()
    {

    }

    public void EscenaJuego()
    {
        // Si todavía usás escenas, queda acá
        // SceneManager.LoadScene("Intro");
    }

    public void CargarNivel(string NombreNivel)
    {
        // SceneManager.LoadScene(NombreNivel);
    }

    public void BotonAñadido()
    {
        semillas.gameObject.SetActive(false);
    }

    public void CerrarTienda()
    {
        panelTienda.SetActive(false); //  Esto solo oculta la tienda, no resetea nada
    }
}
