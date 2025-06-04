using UnityEngine;

public class InvernaderoToggle : MonoBehaviour
{
    public GameObject pestañaInvernadero;

    private bool estaAbierta = false;

    public void AlternarPestaña()
    {
        estaAbierta = !estaAbierta;
        pestañaInvernadero.SetActive(estaAbierta);
    }
}
