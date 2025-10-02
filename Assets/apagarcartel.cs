using UnityEngine;

public class ApagarCartel : MonoBehaviour
{
    public GameObject cartel;

    void Start()
    {
        if (cartel != null)
            cartel.SetActive(true);
    }

    public void ComenzarJuego()
    {
        if (cartel != null)
            cartel.SetActive(false);
    }
}