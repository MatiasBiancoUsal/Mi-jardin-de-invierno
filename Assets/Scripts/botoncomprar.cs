using UnityEngine;
using UnityEngine.UI;

public class botoncomprar : MonoBehaviour
{
    public Button botonComprar;
    public GameObject botonAñadido;

    void Start()
    {
        //parte nueva guada: Verifica si ya se compro anteriormente
        if (EstadoObjetosEscena.macetaYaComprada)
        {
            //parte nueva guada: Ya fue comprada> ocultar boton, mostrar check
            if (botonComprar != null)
                botonComprar.gameObject.SetActive(false);

            if (botonAñadido != null)
                botonAñadido.SetActive(true);
        }
        else
        {
            //luisi 
            if (botonAñadido != null)
                botonAñadido.SetActive(false);

            if (botonComprar != null)
                botonComprar.onClick.AddListener(Comprar);
        }
    }

    void Comprar()
    {
        //luisi: Ocultar botón, mostrar check
        if (botonComprar != null)
            botonComprar.gameObject.SetActive(false);

        if (botonAñadido != null)
            botonAñadido.SetActive(true);

        //parte nueva guada: Marcamos que se compro y se debe activar en la otra escena
        EstadoObjetosEscena.mostrarMacetaEnInvernadero = true;
        EstadoObjetosEscena.macetaYaComprada = true;
    }
}

