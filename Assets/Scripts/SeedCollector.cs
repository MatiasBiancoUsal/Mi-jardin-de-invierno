using UnityEngine;

public class SeedCollector : MonoBehaviour
{
    // Se llama cuando el usuario hace clic sobre este objeto
    private void OnMouseDown()
    {
        Debug.Log("¡Semilla recolectada: " + gameObject.name + "!");
        Destroy(gameObject); // Elimina esta semilla de la escena
    }
}

