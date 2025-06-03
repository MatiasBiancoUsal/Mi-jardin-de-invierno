using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regaderatrigger : MonoBehaviour
{
  
    //Codigo para activar la animacion en primera instancia 
    //aun no funciona 
    //hay que modificar para que sea point and click 
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Regplay");
        }
    }

}
