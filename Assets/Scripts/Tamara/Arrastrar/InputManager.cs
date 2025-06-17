using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //public Grid grid;

    [SerializeField]
    public Camera sceneCamera;
    private Vector3 lastPosition;

    [SerializeField]
    public LayerMask groundLayerMask;

    // Devuelve la posición del mouse en coordenadas del mundo
    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = sceneCamera.nearClipPlane;
        Ray ray = sceneCamera.ScreenPointToRay(mouseWorldPos);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (Physics.Raycast(ray,out hit, 100, groundLayerMask))
        {
            lastPosition = hit.point;
        }

        return mouseWorldPos;
    }

    // Convierte una posición del mundo a una celda del grid
    //public Vector3Int WorldToCell(Vector3 worldPos)
    //{
    //    return grid.WorldToCell(worldPos);
    //}
    //public bool GetPlacementInput()
    //    => Input.GetMouseButtonDown(0);
}
