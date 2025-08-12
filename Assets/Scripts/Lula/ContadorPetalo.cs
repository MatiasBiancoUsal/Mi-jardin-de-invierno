using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContadorPetalo : MonoBehaviour
{

    public static ContadorPetalo instancia;

    [Header("Visual")]
    public Image imagenFlor;           // El componente UI Image que muestra la flor
    public Sprite[] etapasFlor;        // Array con las imágenes en orden: 0 pétalos, 1 pétalo, etc.

    private int contadorPetalos = 0;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Asegurarnos de que arranque en la imagen inicial
        ActualizarFlor();
    }

    public void SumarPetalo()
    {
        contadorPetalos++;
        Debug.Log("Pétalos totales: " + contadorPetalos);

        // Cambiar sprite de flor según cantidad
        ActualizarFlor();
    }

    public int CantidadPetalos()
    {
        return contadorPetalos;
    }

    private void ActualizarFlor()
    {
        if (imagenFlor != null && etapasFlor != null && etapasFlor.Length > 0)
        {
            // Usar el índice correspondiente, pero no pasar del último sprite
            int indice = Mathf.Clamp(contadorPetalos, 0, etapasFlor.Length - 1);
            imagenFlor.sprite = etapasFlor[indice];
        }
    }
}
