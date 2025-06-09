using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZonePisoRotacion : MonoBehaviour
{
    public string tagObjetoValido = "SnapZonePisoRotacion"; // O el tag que uses para tus muebles
    public bool isOccupied = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagObjetoValido))
        {
            other.transform.position = transform.position;
            other.transform.rotation = Quaternion.Euler(0, 90, 0); // Rotación 90° en Y
        }
    }
    public Transform GetSnapPosition()
    {
        return transform;
    }

    public void Occupy()
    {
        isOccupied = true;
    }

    public void Release()
    {
        isOccupied = false;
    }
}

