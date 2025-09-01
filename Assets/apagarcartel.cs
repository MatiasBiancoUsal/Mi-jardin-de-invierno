using UnityEngine;

public class apagarcartel : MonoBehaviour
{
    public GameObject cartel; 
    void Start()
    {
        
        cartel.SetActive(true);
    }

    public void ComenzarJuego()
    {
        
        cartel.SetActive(false);
    }
}