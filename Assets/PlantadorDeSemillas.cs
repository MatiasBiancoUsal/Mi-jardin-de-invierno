using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorDeAnimacion : MonoBehaviour
{
    private Animator animator;
    private bool modoActivacion = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (modoActivacion && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("maceta")) // o el tag que uses
                {
                    animator.SetTrigger("ActivarAnimacion");
                    modoActivacion = false;
                }
            }
        }
    }

    public void ActivarModo()
    {
        modoActivacion = true;
    }
}