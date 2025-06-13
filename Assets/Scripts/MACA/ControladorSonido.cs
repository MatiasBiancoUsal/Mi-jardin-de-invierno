using UnityEngine;
using UnityEngine.UI;

public class ControladorSonido : MonoBehaviour
{
    public Slider sliderVolumen;
    public Button botonMute;
    public RectTransform handleTransform;  // Referencia al handle del slider

    private float volumenAnterior = 1f;
    private bool estaMuteado = false;

    void Start()
    {
        sliderVolumen.onValueChanged.AddListener(CambiarVolumen);
        botonMute.onClick.AddListener(AlternarMute);

        // Inicializar slider y tamaño del handle según volumen actual
        sliderVolumen.value = AudioListener.volume;
        AjustarTamanoHandle(AudioListener.volume);
    }

    void CambiarVolumen(float valor)
    {
        AudioListener.volume = valor;

        if (valor > 0)
        {
            estaMuteado = false;
            volumenAnterior = valor;
        }

        AjustarTamanoHandle(valor);
    }

    void AlternarMute()
    {
        estaMuteado = !estaMuteado;

        if (estaMuteado)
        {
            volumenAnterior = sliderVolumen.value;
            AudioListener.volume = 0f;
            sliderVolumen.value = 0f;
        }
        else
        {
            AudioListener.volume = volumenAnterior;
            sliderVolumen.value = volumenAnterior;
        }

        AjustarTamanoHandle(AudioListener.volume);
    }

    void AjustarTamanoHandle(float volumen)
    {
        // Cambia tamaño entre 0.5 y 1.5 veces según volumen (0-1)
        float escala = Mathf.Lerp(0.5f, 1.5f, volumen);
        handleTransform.localScale = new Vector3(escala, escala, 1f);
    }
}
