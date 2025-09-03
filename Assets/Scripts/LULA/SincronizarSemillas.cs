using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SincronizarSemillas : MonoBehaviour
{

    public TMP_Text textoContadorSemillas;

    void Start()
    {
        textoContadorSemillas.text = PlayerPrefs.GetString("Semillas", "0");
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetString("Semillas", textoContadorSemillas.text);
    }

}
