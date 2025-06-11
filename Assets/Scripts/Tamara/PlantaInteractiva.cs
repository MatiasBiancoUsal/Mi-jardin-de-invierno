using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaInteractiva : MonoBehaviour
{
    public GameObject cartelUI;

    void Update()
    {
        // Bot�n derecho
        if (Input.GetMouseButtonDown(1))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                
                if (hit.transform == transform || hit.transform.IsChildOf(transform))
                {
                    
                    cartelUI.SetActive(!cartelUI.activeSelf);
                }
            }
        }
    }
}



