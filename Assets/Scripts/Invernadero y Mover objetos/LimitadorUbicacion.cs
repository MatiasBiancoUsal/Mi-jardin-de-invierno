using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitadorUbicacion : MonoBehaviour
{
    public Collider areaInvernadero; // Area valida para colocar objetos
    private Vector3 ultimaPosicionValida;
    public float tamanioCelda = 1f; // ajustar esto desde el Inspector

    void Start()
    {
        ultimaPosicionValida = transform.position;
    }

    void Update()
    {
        if (EstaDentroDelInvernadero())
        {
            ultimaPosicionValida = transform.position;
        }
    }

    public void IntentarUbicar()
    {
        if (!EstaDentroDelInvernadero())
        {
            transform.position = ultimaPosicionValida;
            Debug.Log("No podés ubicar este objeto fuera del invernadero.");
        }
    }

    public bool EstaDentroDelInvernadero()
    {
        if (areaInvernadero == null) return true;

        Ray ray = new Ray(transform.position + Vector3.up * 0.5f, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f)) // distancia segun tamaño objetos
        {

            if (hit.collider == areaInvernadero)
            {
                return true;
            }
        }

        return false;
    }

    public void AjustarAGrilla()
    {
        Vector3 posicion = transform.position;

        float x = Mathf.Round(posicion.x / tamanioCelda) * tamanioCelda;
        float y = posicion.y; // Dejar la altura actual
        float z = Mathf.Round(posicion.z / tamanioCelda) * tamanioCelda;

        transform.position = new Vector3(x, y, z);
    }

}
