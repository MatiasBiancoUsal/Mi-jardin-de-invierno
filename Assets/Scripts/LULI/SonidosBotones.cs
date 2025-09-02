using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SonidosBotones : MonoBehaviour
{
    private Animator animator;
    private string animacionAnterior = "";

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtenemos el estado actual del Animator (capa 0)
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Detectamos si cambió de animación
        if (stateInfo.IsName("Regar") && animacionAnterior != "Regar")
        {
            AudioManager.instance?.ReproducirSonido("regar");
            animacionAnterior = "Regar";
        }
        else if (stateInfo.IsName("Plantar") && animacionAnterior != "Plantar")
        {
            AudioManager.instance?.ReproducirSonido("plantar");
            animacionAnterior = "Plantar";
        }
        else if (stateInfo.IsName("Abono") && animacionAnterior != "Abono")
        {
            AudioManager.instance?.ReproducirSonido("abonar");
            animacionAnterior = "Abono";
        }
        else if (!stateInfo.IsName("Regar") && 
                 !stateInfo.IsName("Plantar") && 
                 !stateInfo.IsName("Abono"))
        {
            // Si no estamos en ninguna animación especial, reseteamos
            animacionAnterior = "";
        }
    }
}
