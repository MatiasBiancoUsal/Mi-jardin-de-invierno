using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Lula;
using UnityEngine;

public class Regaderatrigger : MonoBehaviour
{
    public Planta planta;
    private Animator anim;
    private bool idleregar = false;

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

                if (!idleregar && objetoClickeado == gameObject)
                {
                    idleregar = true;
                }
                else if (idleregar && objetoClickeado.GetComponent<Planta>() == planta)
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
        planta.SubirAgua();
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
