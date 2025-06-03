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
    public ControladorGrilla grilla;
    public float alturaObjeto = 0.5f;

    private Renderer rend;
    private Color colorOriginal;

    void Start()
    {
        camara = Camera.main;
        limitador = GetComponent<LimitadorUbicacion>();

        // Guardamos el material original
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

            if (rend != null)
            {
                rend.material.color = limitador.EstaDentroDelInvernadero() ? Color.green : Color.red;
            }
        }
    }

    void OnMouseUp()
    {
        arrastrando = false;
        limitador.IntentarUbicar();

        if (rend != null)
        {
            rend.material.color = colorOriginal;
        }

        if (grilla != null)
        {
            Vector3 ajustada = grilla.ObtenerPosicionAjustada(transform.position);
            if (grilla.EstaDentroDeLaGrilla(ajustada))
            {
                transform.position = new Vector3(ajustada.x, alturaObjeto, ajustada.z);
            }
            else
            {
                Debug.Log("¡Fuera de la grilla!");
            }
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
