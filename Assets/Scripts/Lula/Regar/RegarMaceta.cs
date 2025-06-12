using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RegarMaceta : MonoBehaviour
{
    public GameObject regadera;          // La regadera hija, asignar en inspector
    public GameObject semilla;           // La semilla que se activa al completar riego
    public int RiegoNecesario = 2;       // Cantidad de riegos necesarios, configurable
    public TMP_Text textoRiego;          // Texto para mostrar el contador

    private int contadorAgua = 0;

    void OnMouseDown()
    {
        if (UIRiego.modoRiego)
        {
            if (regadera != null)
            {
                regadera.SetActive(true);       // Activa la regadera para iniciar riego
                Debug.Log("Regadera activada en esta maceta");
            }
        }
    }

    public void SumarAgua()
    {
        contadorAgua++;
        Debug.Log($"{contadorAgua} / {RiegoNecesario}");

        if (textoRiego != null)
            textoRiego.text = $"{contadorAgua} / {RiegoNecesario}";

        // Salir del modo riego tras cada riego
        UIRiego.modoRiego = false;

        // Ocultar regadera
        if (regadera != null)
            regadera.SetActive(false);

        if (contadorAgua >= RiegoNecesario)
        {
            Debug.Log("¡Riego completado!");

            if (semilla != null)
                semilla.SetActive(true);

            contadorAgua = 0;  // Reiniciamos el contador

            if (textoRiego != null)
                textoRiego.text = $"{contadorAgua} / {RiegoNecesario}";
        }
    }
}


