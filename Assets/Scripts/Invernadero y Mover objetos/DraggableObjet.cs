using System.Collections;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private bool isDragging = false;
    private SnapZone currentSnapZone = null;
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

                    
                    if (currentSnapZone != null)
                    {
                        currentSnapZone.Release();
                        currentSnapZone = null;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;

            if (lastValidSnapZone != null && !lastValidSnapZone.isOccupied)
            {
                transform.position = lastValidSnapZone.GetSnapPosition().position;
                lastValidSnapZone.Occupy();
                currentSnapZone = lastValidSnapZone;
            }
            else
            {
                transform.position = originalPosition;
            }

            lastValidSnapZone = null;
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

    private SnapZone lastValidSnapZone = null;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró al trigger con: " + other.gameObject.name);

        if (other.CompareTag("SnapZone"))
        {
            Debug.Log("Detectó un SnapZone válido");
            currentSnapZone = other.GetComponent<SnapZone>();
            lastValidSnapZone = currentSnapZone; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SnapZone"))
        {
            Debug.Log("Salió del SnapZone: " + other.name);
            if (other.GetComponent<SnapZone>() == currentSnapZone)
            {
                currentSnapZone = null;
            }
        }
    }
}
