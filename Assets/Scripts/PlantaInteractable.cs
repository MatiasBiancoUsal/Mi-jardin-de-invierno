using UnityEngine;
using UnityEngine.UI;

public class PlantaInteractable : MonoBehaviour
{
    public GameObject iconoUI;

    void OnMouseDown()
    {
        iconoUI.SetActive(true);  // activa el ícono UI
    }
}
