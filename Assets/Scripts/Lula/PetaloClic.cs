using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PetaloClic : MonoBehaviour
{
    void OnMouseDown()
    {
        if (ContadorPetalo.instancia != null)
        {
            ContadorPetalo.instancia.SumarPetalo();
        }
        else
        {
            Debug.LogWarning("No se encontró el ContadorPetalos en la escena.");
        }

        gameObject.SetActive(false);
    }
}
