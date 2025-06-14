using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regaderatrigger : MonoBehaviour
{
    private Animator anim;
    private bool idleregar = false;
    private RegarMaceta macetaPadre;

    void Start()
    {
        anim = GetComponent<Animator>();
        macetaPadre = GetComponentInParent<RegarMaceta>();
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

                if (!idleregar && objetoClickeado == gameObject)
                {
                    idleregar = true;
                }
                else if (idleregar && objetoClickeado.CompareTag("regaract"))
                {
                    anim.SetBool("Regando", true);
                    idleregar = false;

                    // Esperamos 1 segundo para que se vea la animaci�n
                    Invoke(nameof(SumarYDesactivar), 2.6f);
                }
            }
        }
    }

    void SumarYDesactivar()
    {
        if (macetaPadre != null)
            macetaPadre.SumarAgua();

        anim.SetBool("Regando", false);
    }

    public void SumarAguaMaceta()
    {
        Debug.Log("La maceta recibió agua");
    }

    public void SumarAgua()
    {
    Debug.Log("La maceta fue regada con SumARagua!");
    }
}
