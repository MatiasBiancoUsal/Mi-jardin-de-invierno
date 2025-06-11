using UnityEngine;
using UnityEngine.UI;

public class botoncomprar : MonoBehaviour
{
    public Button botonComprar;
    public GameObject botonA�adido;

    void Start()
    {
        // Asegura que el bot�n a�adido est� oculto al inicio
        if (botonA�adido != null)
            botonA�adido.SetActive(false);

        if (botonComprar != null)
            botonComprar.onClick.AddListener(Comprar);
    }

    void Comprar()
    {
        if (botonComprar != null)
            botonComprar.gameObject.SetActive(false);

        if (botonA�adido != null)
            botonA�adido.SetActive(true);
    }
}

