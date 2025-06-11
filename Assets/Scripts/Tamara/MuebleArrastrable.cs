using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuebleArrastrable : MonoBehaviour
{
    private bool isDragging = false;
    private SnapZonePared currentSnapZonePared = null;
    private SnapZonePared lastValidSnapZonePared = null;
    private Vector3 originalPosition;

    void Update()
    {
        if (isDragging)
        {
            Vector3 newPos = GetMouseWorldPosition();
            transform.position = newPos;
        }

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
            Debug.Log("Entró al SnapZonePared: " + other.name);
            lastValidSnapZonePared = other.GetComponent<SnapZonePared>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SnapZonePared"))
        {
            Debug.Log("Salió del SnapZonePared: " + other.name);
            if (other.GetComponent<SnapZonePared>() == lastValidSnapZonePared)
            {
                lastValidSnapZonePared = null;
            }
        }
    }
}
