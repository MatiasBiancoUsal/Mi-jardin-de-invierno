using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estante : MonoBehaviour
{
    public List<Transform> puntosParaPlantas = new List<Transform>();
    private HashSet<Transform> puntosOcupados = new HashSet<Transform>();

    public Transform ObtenerPuntoDisponible()
    {
        foreach (Transform punto in puntosParaPlantas)
        {
            if (!puntosOcupados.Contains(punto))
            {
                puntosOcupados.Add(punto);
                return punto;
            }
        }
        return null;
    }

    public void LiberarPunto(Transform punto)
    {
        if (puntosOcupados.Contains(punto))
        {
            puntosOcupados.Remove(punto);
        }
    }
}
