using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprarObjetos : MonoBehaviour
{
    public string nombreDelObjeto; // Ej: "Rosa"

    public GameObject objetoVisual; // (opcional) para activar algo visual al comprar

    public void Comprar()
    {
        PlayerPrefs.SetInt(nombreDelObjeto, 1); // Marca como comprado
        PlayerPrefs.Save(); // Guarda los cambios

        if (objetoVisual != null)
            objetoVisual.SetActive(true);

        Debug.Log("Compraste: " + nombreDelObjeto);
    }
}
