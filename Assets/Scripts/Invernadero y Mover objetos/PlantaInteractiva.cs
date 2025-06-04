using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantaInteractiva : MonoBehaviour
{
    public GameObject cartelUI;
    public CartelManager cartelManager;

    void OnMouseDown()
    {
        if (cartelUI != null)
        {
            cartelUI.SetActive(true);
            // cambiar la frase o mostrar/ocultar el sol/gota desde acá 
            cartelManager.MostrarCartel();
        }
    }
}

