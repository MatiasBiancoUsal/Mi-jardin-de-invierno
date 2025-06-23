using UnityEngine;
using UnityEngine.UI;

public class botoncomprar : MonoBehaviour
{
    public Button botonComprar;
    public GameObject botonAñadido;
    public string nombreObjeto; 

    void Start()
    {
        if (PlayerPrefs.GetInt(nombreObjeto + "_Comprado", 0) == 1)
        {
            if (botonComprar != null)
                botonComprar.gameObject.SetActive(false);

            if (botonAñadido != null)
                botonAñadido.SetActive(true);
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
    }
}