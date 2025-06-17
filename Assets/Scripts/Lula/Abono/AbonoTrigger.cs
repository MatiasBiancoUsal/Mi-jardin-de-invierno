using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Lula;
using UnityEngine;

public class AbonoTrigger : MonoBehaviour
{
    public Planta planta;
    private Animator anim;
    private bool idleAbonar = false;

    void Start()
    {
        anim = GetComponent<Animator>();
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

                if (!idleAbonar && objetoClickeado == gameObject)
                {
                    idleAbonar = true;
                }
                else if (idleAbonar && objetoClickeado.GetComponent<Planta>() == planta)
                {
                    anim.SetBool("Abonando", true);
                    idleAbonar = false;

                    // Esperamos 1 segundo para que se vea la animaci�n
                    Invoke(nameof(SumarYDesactivar), 2.6f);
                }
            }
        }
    }

    void SumarYDesactivar()
    {
        planta.SubirAbono();
        anim.SetBool("Abonando", false);
    }

    public void SumarAbonoMaceta()
    {
        Debug.Log("La maceta recibió abono");
    }

    public void SumarAbono()
    {
        Debug.Log("La maceta fue regada con SumarAbono!");
    }
}
