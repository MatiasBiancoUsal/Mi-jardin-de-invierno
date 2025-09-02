using UnityEngine;

public class RegaderaSonidos : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Regar"))
        {
            AudioManager.instance.ReproducirSonido("regar");
        }
    }

     public void SonidoRegar()
    {
        AudioManager.instance.ReproducirSonido("regar");
    }
}
