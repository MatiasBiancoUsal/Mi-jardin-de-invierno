using UnityEngine;
using UnityEngine.UI;

public class botoncomprar : MonoBehaviour
{
    public Button botonComprar;
    public GameObject botonAñadido;

    void Start()
    {
        //  NUEVO: Verificamos si ya se compró anteriormente
        if (EstadoObjetosEscena.macetaYaComprada)
        {
            //  Ya fue comprada → ocultar botón, mostrar check
            if (botonComprar != null)
                botonComprar.gameObject.SetActive(false);

            if (botonAñadido != null)
                botonAñadido.SetActive(true);
        }
        else
        {
            // PARTE QUE YA TENÍAS: Inicializa el estado normal
            if (botonAñadido != null)
                botonAñadido.SetActive(false);

            if (botonComprar != null)
                botonComprar.onClick.AddListener(Comprar);
        }
    }

    void Comprar()
    {
        //  PARTE QUE YA TENÍAS: Ocultar botón, mostrar check
        if (botonComprar != null)
            botonComprar.gameObject.SetActive(false);

        if (botonAñadido != null)
            botonAñadido.SetActive(true);

        // NUEVO: Marcamos que se compró y se debe activar en la otra escena
        EstadoObjetosEscena.mostrarMacetaEnInvernadero = true;
        EstadoObjetosEscena.macetaYaComprada = true;
    }
}