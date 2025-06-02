using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DibujarGrilla : MonoBehaviour
{
    public float tamanoCelda = 1f;
    public int filas = 10;
    public int columnas = 5;
    public Vector3 origen = Vector3.zero;

    private Dictionary<Vector2Int, GameObject> grillaOcupada = new Dictionary<Vector2Int, GameObject>();

    public Vector3 ObtenerPosicionAjustada(Vector3 posicion)
    {
        Vector3 localPos = posicion - origen;
        int x = Mathf.RoundToInt(localPos.x / tamanoCelda);
        int z = Mathf.RoundToInt(localPos.z / tamanoCelda);
        return new Vector3(x * tamanoCelda, 0f, z * tamanoCelda) + origen;
    }

    public bool EstaDentroDeLaGrilla(Vector3 posicion)
    {
        Vector3 localPos = posicion - origen;
        int x = Mathf.RoundToInt(localPos.x / tamanoCelda);
        int z = Mathf.RoundToInt(localPos.z / tamanoCelda);
        return x >= 0 && x < columnas && z >= 0 && z < filas;
    }

    public Vector2Int ObtenerCelda(Vector3 posicion)
    {
        Vector3 localPos = posicion - origen;
        int x = Mathf.RoundToInt(localPos.x / tamanoCelda);
        int z = Mathf.RoundToInt(localPos.z / tamanoCelda);
        return new Vector2Int(x, z);
    }

    public bool EstaOcupada(Vector2Int celda)
    {
        return grillaOcupada.ContainsKey(celda);
    }

    public void OcuparCelda(Vector2Int celda, GameObject objeto)
    {
        grillaOcupada[celda] = objeto;
    }

    public void LiberarCelda(Vector2Int celda)
    {
        if (grillaOcupada.ContainsKey(celda))
        {
            grillaOcupada.Remove(celda);
        }
    }

    public GameObject ObtenerObjetoEnCelda(Vector2Int celda)
    {
        grillaOcupada.TryGetValue(celda, out var obj);
        return obj;
    }
}
