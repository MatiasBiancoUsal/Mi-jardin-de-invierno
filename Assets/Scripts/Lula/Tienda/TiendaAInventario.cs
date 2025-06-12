using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaAInventario : MonoBehaviour
{
    public GameObject[] objetosInventario; // Los objetos a mostrar
    public string[] nombresObjetos;        // Deben tener el mismo orden que arriba

    void Start()
    {
        for (int i = 0; i < objetosInventario.Length; i++)
        {
            if (PlayerPrefs.GetInt(nombresObjetos[i], 0) == 1)
            {
                objetosInventario[i].SetActive(true);
            }
            else
            {
                objetosInventario[i].SetActive(false);
            }
        }
    }
}
