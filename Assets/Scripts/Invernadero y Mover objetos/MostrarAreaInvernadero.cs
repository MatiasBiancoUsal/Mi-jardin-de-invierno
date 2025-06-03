using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarAreaInvernadero : MonoBehaviour
{

    public Collider areaInvernadero;
    public Color color = new Color(0f, 1f, 0f, 0.25f);

    void OnDrawGizmos()
    {
        if (areaInvernadero == null) return;

        Gizmos.color = color;
        Gizmos.DrawCube(areaInvernadero.bounds.center, areaInvernadero.bounds.size);
    }
}