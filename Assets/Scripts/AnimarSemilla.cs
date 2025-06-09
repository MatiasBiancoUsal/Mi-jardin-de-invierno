using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimarSemilla : MonoBehaviour
{
    public Animator anim;
    public Transform semillaTransform;
    private bool puedePlantar = false;

    void Start()
    {
        // Ocultamos la semilla al inicio
        semillaTransform.gameObject.SetActive(false);
    }

    // Método que se llama desde el botón
    public void ActivarModoPlantar()
    {
        puedePlantar = true;
        Debug.Log("Modo plantar activado. Hacé clic en una maceta.");
    }

    void Update()
    {
        if (puedePlantar && Input.GetMouseButtonDown(0)) // Clic izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Maceta"))
                {
                    Vector3 posicionMaceta = hit.collider.transform.position;
                    ReproducirAnimacion(posicionMaceta);
                    puedePlantar = false;
                }
            }
        }
    }

    void ReproducirAnimacion(Vector3 posicion)
    {
        semillaTransform.position = posicion + new Vector3(0, 0.5f, 0); // offset visual
        semillaTransform.gameObject.SetActive(true); // Hacer visible la semilla

        anim.Rebind(); // Reiniciar animator
        anim.Update(0f);

        anim.SetBool("ActivarAr", true);

        Invoke(nameof(ResetAnimacion), 1f); // Duración de la animación
    }

    void ResetAnimacion()
    {
        anim.SetBool("ActivarAr", false);
        semillaTransform.gameObject.SetActive(false); // Ocultamos la semilla
    }
}