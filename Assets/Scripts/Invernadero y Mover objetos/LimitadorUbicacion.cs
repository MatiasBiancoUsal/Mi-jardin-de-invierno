using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitadorUbicacion : MonoBehaviour
{
    public Collider areaInvernadero;
    private Vector3 ultimaPosicionValida;
    public float tamanioCelda = 1f;
    private Vector3? celdaOcupadaAnterior;
    private HashSet<Vector3> celdasOcupadas = new HashSet<Vector3>();
    private bool estoySiendoArrastrado = false;
    private ControladorGrilla grilla;


    void Start()
    {
        grilla = FindFirstObjectByType<ControladorGrilla>();
        if (grilla == null)
        {
            Debug.LogError("No se encontró un objeto con ControladorGrilla en la escena.");
        }

        ultimaPosicionValida = transform.position;
        celdaOcupadaAnterior = ObtenerCeldaActual();

        if (celdaOcupadaAnterior.HasValue && !EstaCeldaOcupada(celdaOcupadaAnterior.Value))
        {
            OcuparCelda(celdaOcupadaAnterior.Value);
        }
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
        Vector3 ajustada = grilla.ObtenerPosicionAjustada(transform.position);
        Vector2Int celda = grilla.ObtenerCelda(ajustada);

        if (!EstaDentroDelInvernadero() || grilla.EstaOcupada(celda))
        {
            transform.position = ultimaPosicionValida;
        }
        else
        {
            if (celdaOcupadaAnterior.HasValue)
                grilla.LiberarCelda(grilla.ObtenerCelda(celdaOcupadaAnterior.Value));

            grilla.OcuparCelda(celda, gameObject);
            transform.position = new Vector3(ajustada.x, 0.5f, ajustada.z);
            celdaOcupadaAnterior = ajustada;
            ultimaPosicionValida = transform.position;

        }
    }

    public bool EstaDentroDelInvernadero()
    {
        if (areaInvernadero == null) return true;

        Ray ray = new Ray(transform.position + Vector3.up * 0.5f, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f))
        {
            Debug.Log("Hit con: " + hit.collider.name);

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
        float y = posicion.y;
        float z = Mathf.Round(posicion.z / tamanioCelda) * tamanioCelda;

        transform.position = new Vector3(x, y, z);
    }

    public Vector3 ObtenerCeldaActual()
    {
        Vector3 posicion = transform.position;
        float x = Mathf.Round(posicion.x / tamanioCelda) * tamanioCelda;
        float z = Mathf.Round(posicion.z / tamanioCelda) * tamanioCelda;
        return new Vector3(x, 0f, z);
    }

    public bool EstaCeldaOcupada(Vector3 celda)
    {
        return celdasOcupadas.Contains(celda) && (!celdaOcupadaAnterior.HasValue || celda != celdaOcupadaAnterior.Value);
    }

    public void OcuparCelda(Vector3 celda)
    {
        celdasOcupadas.Add(celda);
    }

    public void LiberarCelda(Vector3 celda)
    {
        if (!estoySiendoArrastrado)
    {
        celdasOcupadas.Remove(celda);
    }

    }

    public void LiberarCeldaActual()
    {
        if (celdaOcupadaAnterior.HasValue)
        {
            LiberarCelda(celdaOcupadaAnterior.Value);
            celdaOcupadaAnterior = null;
        }
    }

    public void EstoySiendoArrastrado(bool estado)
    {
        estoySiendoArrastrado = estado;
    }
}
