using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorSemillas : MonoBehaviour
{
    public static ContadorSemillas instancia;  // Singleton para acceso global

    public TMP_Text textoContadorSemillas;
    private int contadorSemillas = 0;

    void Awake()
    {
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
        Debug.Log("Semillas totales: " + contadorSemillas);

        if (textoContadorSemillas != null)
            textoContadorSemillas.text = $"{contadorSemillas}";
    }
}
