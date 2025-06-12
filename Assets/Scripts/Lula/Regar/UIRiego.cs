using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRiego : MonoBehaviour
{
    public static bool modoRiego = false;

    public void ToggleModoRiego()
    {
        modoRiego = !modoRiego;
        Debug.Log($"Modo riego: {modoRiego}");

        if (!modoRiego)
        {
            // Desactiva todas las regaderas visibles cuando se apaga el modo
            Regaderatrigger[] regaderas = FindObjectsOfType<Regaderatrigger>();
            foreach (Regaderatrigger r in regaderas)
            {
                r.gameObject.SetActive(false);
            }
        }
    }
}
