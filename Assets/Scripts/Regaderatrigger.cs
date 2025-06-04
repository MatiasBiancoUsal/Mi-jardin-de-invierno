using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regaderatrigger : MonoBehaviour
{
  
    //Codigo para activar la animacion en primera instancia 
    //aun no funciona 
    //hay que modificar para que sea point and click 
    private Animator anim;
    private bool idleregar = false; 
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;// para poder hacer cllic en un espacio3d

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
                }
            }
        }
        
        

}
}
