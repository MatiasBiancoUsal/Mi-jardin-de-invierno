using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuebleArrastrable : MonoBehaviour
{
    public bool isDragging = false;
    public SnapZonePared currentSnapZonePared = null;

    private SnapZonePared lastValidSnapZonePared = null;
    private Vector3 originalPosition;

    void Update()
    {
        // Seguir el mouse
        if (isDragging)
        {
            Vector3 newPos = GetMouseWorldPosition();
            transform.position = newPos;
        }

        // Al hacer clic, empieza a arrastrar si toqué el objeto
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform || hit.transform.IsChildOf(transform))
                {
                    isDragging = true;
                    originalPosition = transform.position;

                    if (currentSnapZonePared != null)
                    {
                        currentSnapZonePared.Release();
                        currentSnapZonePared = null;
                    }
                }
            }
        }

        // Al soltar el clic, intento "pegarlo"
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;

            if (lastValidSnapZonePared != null && !lastValidSnapZonePared.isOccupied)
            {
                transform.position = lastValidSnapZonePared.GetSnapPosition().position;
                lastValidSnapZonePared.Occupy();
                currentSnapZonePared = lastValidSnapZonePared;
            }
            else
            {
                transform.position = originalPosition;
            }

            lastValidSnapZonePared = null;
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            return hit.point;
        }
        return transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnapZonePared"))
        {
            SnapZonePared snap = other.GetComponent<SnapZonePared>();
            if (snap != null && !snap.isOccupied)
            {
                lastValidSnapZonePared = snap;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SnapZonePared"))
        {
            SnapZonePared snap = other.GetComponent<SnapZonePared>();
            if (snap == lastValidSnapZonePared)
            {
                lastValidSnapZonePared = null;
            }
        }
    }
}
