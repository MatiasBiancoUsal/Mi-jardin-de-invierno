using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZonePared : MonoBehaviour
{
    public string tagObjetoValido = "SnapZonePared"; // Mismo tag que el anterior

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagObjetoValido))
        {
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation; // Mantiene rotación del snapzone
        }
    }
}
