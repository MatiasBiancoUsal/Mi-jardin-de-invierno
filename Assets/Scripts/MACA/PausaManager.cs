using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausaManager : MonoBehaviour
{
    public GameObject overlayUI;
    public Button botonIrInicio;
    public Image iconoBotonPausa;
    public Sprite iconoPausa;
    public Sprite iconoPlay;

    private bool enPausa = false;

    public void TogglePausa()
    {
        enPausa = !enPausa;

        if (enPausa)
        {
            Time.timeScale = 0;
            overlayUI.SetActive(true);
            iconoBotonPausa.sprite = iconoPlay;
        }
        else
        {
            Time.timeScale = 1;
            overlayUI.SetActive(false);
            iconoBotonPausa.sprite = iconoPausa;
        }
    }

    public void IrPantallaInicio()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PantallaInicio"); // Asegurate que este nombre coincida
    }
}
