using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private bool isDragging = false;
    private Transform lastValidSnapZone = null;

    void Update()
    {
        if (isDragging)
        {
            Vector3 newPos = GetMouseWorldPosition();
            transform.position = newPos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Comenzar drag si el mouse está cerca del objeto
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == transform)
            {
                isDragging = true;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;

            if (lastValidSnapZone != null)
            {
                transform.position = lastValidSnapZone.position;
            }
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
        if (other.CompareTag("SnapZone"))
        {
            lastValidSnapZone = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SnapZone") && other.transform == lastValidSnapZone)
        {
            lastValidSnapZone = null;
        }
    }
}

