using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbonoTrigger : MonoBehaviour
{
    private Animator anim;
    private bool idleAbono = false;
    private AbonarMaceta macetaPadre;

    void Start()
    {
        anim = GetComponent<Animator>();
        macetaPadre = GetComponentInParent<AbonarMaceta>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject objetoClickeado = hit.collider.gameObject;

                if (!idleAbono && objetoClickeado == gameObject)
                {
                    idleAbono = true;
                }
                else if (idleAbono && objetoClickeado.CompareTag("abonoact"))
                {
                    anim.SetBool("Abonando", true);
                    idleAbono = false;

                    // Espera a que termine la animación antes de sumar
                    Invoke(nameof(SumarYDesactivar), 2.6f); // Ajustá el tiempo si es necesario
                }
            }
        }
    }

    void SumarYDesactivar()
    {
        if (macetaPadre != null)
            macetaPadre.SumarAbono();

        anim.SetBool("Abonando", false);
    }
}
