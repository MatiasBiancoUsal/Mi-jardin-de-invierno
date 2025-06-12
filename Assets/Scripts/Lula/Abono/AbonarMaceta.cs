using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbonarMaceta : MonoBehaviour
{
    public GameObject abonera;           // La abonera hija, asignar en inspector
    public GameObject semilla;           // La semilla que se activa al completar abono
    public int AbonoNecesario = 2;       // Cantidad de abonos necesarios, configurable
    public TMP_Text textoAbono;          // Texto para mostrar el contador

    private int contadorAbono = 0;

    void OnMouseDown()
    {
        Debug.Log("Hiciste clic en la maceta");

        if (UIAbono.modoAbono)
        {
            Debug.Log("Modo abono activo");

            if (abonera != null)
            {
                abonera.SetActive(true);
                Debug.Log("Abonera activada en esta maceta");
            }
            else
            {
                Debug.LogWarning("Abonera NO está asignada en el Inspector");
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && UIAbono.modoAbono)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Clic en la maceta con Raycast");

                    if (abonera != null)
                    {
                        abonera.SetActive(true);
                        Debug.Log("Abonera activada en esta maceta");
                    }
                }
            }
        }
    }

    public void SumarAbono()
    {
        contadorAbono++;
        Debug.Log($"{contadorAbono} / {AbonoNecesario}");

        if (textoAbono != null)
            textoAbono.text = $"{contadorAbono} / {AbonoNecesario}";

        // Salir del modo abono tras cada abono
        UIAbono.modoAbono = false;

        // Ocultar abonera
        if (abonera != null)
            abonera.SetActive(false);

        if (contadorAbono >= AbonoNecesario)
        {
            Debug.Log("¡Abono completado!");

            if (semilla != null)
                semilla.SetActive(true);

            contadorAbono = 0;  // Reiniciamos el contador

            if (textoAbono != null)
                textoAbono.text = $"{contadorAbono} / {AbonoNecesario}";
        }
    }
}
