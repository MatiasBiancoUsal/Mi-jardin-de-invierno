using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DibujarGrilla : MonoBehaviour
{
    public int filas = 10;
    public int columnas = 5;
    public float tamanioCelda = 1f;
    public Color colorGrilla = Color.gray;

    void OnDrawGizmos()
    {
        Gizmos.color = colorGrilla;

        Vector3 origen = transform.position;

        for (int i = 0; i <= filas; i++)
        {
            Vector3 inicio = origen + Vector3.forward * i * tamanioCelda;
            Vector3 fin = inicio + Vector3.right * columnas * tamanioCelda;
            Gizmos.DrawLine(inicio, fin);
        }

        for (int j = 0; j <= columnas; j++)
        {
            Vector3 inicio = origen + Vector3.right * j * tamanioCelda;
            Vector3 fin = inicio + Vector3.forward * filas * tamanioCelda;
            Gizmos.DrawLine(inicio, fin);
        }
    }
}



