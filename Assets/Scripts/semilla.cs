using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semilla : MonoBehaviour
{
    private contador contador;

    void Start()
    {
        contador = FindObjectOfType<contador>();
    }

    void OnMouseDown()
    {
        if (contador != null)
        {
            contador.SumarSemilla();
        }

        Destroy(gameObject);
    }
}
