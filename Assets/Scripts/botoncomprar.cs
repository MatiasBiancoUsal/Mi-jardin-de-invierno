using UnityEngine;
using UnityEngine.UI;

public class botoncomprar : MonoBehaviour
{
    public Button botonComprar;
    public GameObject botonAñadido;

    void Start()
    {
        // Asegura que el boton añadido esta oculto al inicio
        if (botonAñadido != null)
            botonAñadido.SetActive(false);

        if (botonComprar != null)
            botonComprar.onClick.AddListener(Comprar);
    }

    void Comprar()
    {
        if (botonComprar != null)
            botonComprar.gameObject.SetActive(false);

        if (botonAñadido != null)
            botonAñadido.SetActive(true);
            EstadoObjetosEscena.mostrarMacetaEnInvernadero = true;
    }
}

