using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartelManager : MonoBehaviour
{
    public GameObject cartelUI;
    private Camera camara;

    void Start()
    {
        camara = Camera.main;
        cartelUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camara.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (!hit.collider.CompareTag("Objeto"))
                {
                    cartelUI.SetActive(false);
                }
            }
            else
            {
                cartelUI.SetActive(false);
            }
        }
    }

    public void MostrarCartel()
    {
        cartelUI.SetActive(true);
    }
}

