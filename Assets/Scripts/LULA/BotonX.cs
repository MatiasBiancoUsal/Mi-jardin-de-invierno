using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonX : MonoBehaviour
{
    [Tooltip("El nombre de la escena a la que quieres cambiar. Asegúrate de que el nombre coincida exactamente.")]
    public string sceneName;

  
    public void ChangeScene()
    {
      
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("El nombre de la escena no ha sido especificado en el Inspector de Unity.");
        }
    }
}
