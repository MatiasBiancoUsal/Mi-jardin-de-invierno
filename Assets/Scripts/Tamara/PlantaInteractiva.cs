using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaInteractiva : MonoBehaviour
{
    public GameObject cartelUI;
    public MensajePlanta mensajePlanta; // Referencia al script que cambia el texto

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform || hit.transform.IsChildOf(transform))
                {
                    bool nuevoEstado = !cartelUI.activeSelf;
                    cartelUI.SetActive(nuevoEstado);

                    if (nuevoEstado)
                    {
                        mensajePlanta.MostrarMensajeAleatorio(); // Ahora sí cambia el texto
                    }
                }
            }
        }
    }
}



