using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MuebleArrastrable : MonoBehaviour
{
    private Vector3 offset;
    private Camera camara;
    private bool arrastrando = false;

    private Renderer rend;
    private Color colorOriginal;

    private Transform snapZoneActual = null;
    private string[] tagsSnapZoneValidos = { "SnapZonePisoRotacion", "SnapZonePiso", "SnapZonePared" };

    void Start()
    {
        camara = Camera.main;

        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            colorOriginal = rend.material.color;
        }
    }

    void OnMouseDown()
    {
        // Usamos el punto real donde se hizo clic para calcular el offset
        Vector3 puntoMouse = ObtenerPuntoMouse();
        offset = transform.position - puntoMouse;
        arrastrando = true;
    }

    void OnMouseDrag()
    {
        if (arrastrando)
        {
            Vector3 puntoMouse = ObtenerPuntoMouse();
            transform.position = puntoMouse + offset;

            if (rend != null)
            {
                rend.material.color = Color.yellow;
            }
        }
    }

    void OnMouseUp()
    {
        arrastrando = false;

        if (rend != null)
        {
            rend.material.color = colorOriginal;
        }

        if (snapZoneActual != null)
        {
            transform.position = snapZoneActual.position;
            transform.rotation = ObtenerRotacionSnapZone(snapZoneActual);
        }

        snapZoneActual = null;
    }

    Vector3 ObtenerPuntoMouse()
    {
        Ray ray = camara.ScreenPointToRay(Input.mousePosition);

        // Acá nos aseguramos de que el raycast detecte la capa "Piso"
        // Si no tenés una capa llamada "Piso", cambiá el nombre abajo o usá `~0` para que detecte todo.
        int layerMask = LayerMask.GetMask("Piso");

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            return hit.point;
        }

        return transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        foreach (string tagSnap in tagsSnapZoneValidos)
        {
            if (other.CompareTag(tagSnap))
            {
                snapZoneActual = other.transform;
                break;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (snapZoneActual != null && other.transform == snapZoneActual)
        {
            snapZoneActual = null;
        }
    }

    Quaternion ObtenerRotacionSnapZone(Transform snapZone)
    {
        if (snapZone.CompareTag("SnapZonePisoRotacion"))
        {
            return Quaternion.Euler(0, 90, 0);
        }
        else if (snapZone.CompareTag("SnapZonePared"))
        {
            return snapZone.rotation;
        }
        else
        {
            return Quaternion.identity;
        }
    }
}
