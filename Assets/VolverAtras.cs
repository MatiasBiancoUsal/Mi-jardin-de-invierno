using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAtras : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            int indiceActual = SceneManager.GetActiveScene().buildIndex;

            if (indiceActual > 0)
            {
                SceneManager.LoadScene(indiceActual - 1);
            }
            else
            {
                Debug.Log("Ya est�s en la primera escena.");
            }
        }
    }
}
