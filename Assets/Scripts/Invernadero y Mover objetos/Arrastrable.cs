using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LimitadorUbicacion))]
public class Arrastrable : MonoBehaviour
{
    private Vector3 offset;
    private Camera camara;
    private LimitadorUbicacion limitador;
    private bool arrastrando = false;

    private Renderer rend;
    private Color colorOriginal;
    private Vector2Int celdaAnterior;

    void Start()
    {
        camara = Camera.main;
        limitador = GetComponent<LimitadorUbicacion>();

        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            colorOriginal = rend.material.color;
        }
    }

    void OnMouseDown()
    {
        arrastrando = true;
        offset = transform.position - ObtenerPuntoMouse();
    }

    void OnMouseDrag()
    {
        if (arrastrando)
        {
            transform.position = ObtenerPuntoMouse() + offset;

            // Color segun posicion
            if (rend != null)
            {
                if (limitador.EstaDentroDelInvernadero())
                    rend.material.color = Color.green;
                else
                    rend.material.color = Color.red;
            }
        }
    }

    void OnMouseUp()
    {
        arrastrando = false;
        limitador.AjustarAGrilla();
        limitador.IntentarUbicar();

        // Volver color original
        if (rend != null)
        {
            rend.material.color = colorOriginal;
        }
    }

    Vector3 ObtenerPuntoMouse()
    {
        Ray ray = camara.ScreenPointToRay(Input.mousePosition);
        int layerMask = LayerMask.GetMask("Piso");

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            return hit.point;
        }
        return transform.position;
    }
}
