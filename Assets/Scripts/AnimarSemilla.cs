using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimarSemilla : MonoBehaviour
{
    public Animator anim;
    private bool puedePlantar = false;

    // Llamado por el botón
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
                    ReproducirAnimacion();
                    puedePlantar = false; // desactiva el modo plantar
                }
            }
        }
    }

    void ReproducirAnimacion()
    {
        anim.SetBool("ActivarAr", true);
        Invoke(nameof(ResetAnimacion), 1f);
    }

    void ResetAnimacion()
    {
        anim.SetBool("ActivarAr", false);
    }
}