using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorSemillas : MonoBehaviour
{
    public static ContadorSemillas instancia;  // Singleton para acceso global

    public int contadorSemillas = 0;
    public event Action<int> cambioSemillas;

    void Awake()
    {
        contadorSemillas = PlayerPrefs.GetInt("Semillas", 0);
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // opcional, si querés que persista entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarSemilla()
    {
        contadorSemillas++;
        PlayerPrefs.SetInt("Semillas", contadorSemillas);
        Debug.Log("Semillas totales: " + contadorSemillas);
        cambioSemillas.Invoke(contadorSemillas);
    }
}