using UnityEngine;
using UnityEngine.UI;

public class botoncomprar : MonoBehaviour
{
    public Button botonComprar;
    public GameObject botonAñadido;
    public string nombreObjeto; 
    public MostrarMaceta mostrarMaceta; // referencia al script MostrarMaceta

    void Start()
    {
        if (PlayerPrefs.GetInt(nombreObjeto + "_Comprado", 0) == 1)
        {
            if (botonComprar != null)
                botonComprar.gameObject.SetActive(false);

            if (botonAñadido != null)
                botonAñadido.SetActive(true);

            if (mostrarMaceta != null)
                mostrarMaceta.ActualizarEstado();
        }
        else
        {
            if (botonAñadido != null)
                botonAñadido.SetActive(false);

            if (botonComprar != null)
                botonComprar.onClick.AddListener(Comprar);
        }
    }

    void Comprar()
    {
        if (botonComprar != null)
            botonComprar.gameObject.SetActive(false);

        if (botonAñadido != null)
            botonAñadido.SetActive(true);

        PlayerPrefs.SetInt(nombreObjeto + "_Comprado", 1);
        PlayerPrefs.Save();

        // Hacer aparecer la maceta en la escena
        if (mostrarMaceta != null)
            mostrarMaceta.ActualizarEstado();
    }
}