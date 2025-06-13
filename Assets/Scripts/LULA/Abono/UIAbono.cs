using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAbono : MonoBehaviour
{
    public static bool modoAbono = false;

    public void ToggleModoAbono()
    {
        modoAbono = !modoAbono;
        Debug.Log($"Modo abono: {modoAbono}");

        if (!modoAbono)
        {
            // Desactiva todas las aboneras visibles cuando se apaga el modo
            AbonoTrigger[] aboneras = FindObjectsOfType<AbonoTrigger>();
            foreach (AbonoTrigger a in aboneras)
            {
                a.gameObject.SetActive(false);
            }
        }
    }
}
