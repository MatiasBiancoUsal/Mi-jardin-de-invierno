using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorPetalo : MonoBehaviour
{

    public static ContadorPetalo instancia;

    public TMP_Text textoContadorPetalos;
    private int contadorPetalos = 0;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // opcional
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPetalo()
    {
        contadorPetalos++;
        Debug.Log("Pétalos totales: " + contadorPetalos);

        if (textoContadorPetalos != null)
            textoContadorPetalos.text = $"{contadorPetalos}";
    }
}
