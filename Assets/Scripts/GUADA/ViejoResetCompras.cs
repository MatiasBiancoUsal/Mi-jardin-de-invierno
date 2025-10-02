using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public KeyCode teclaReset = KeyCode.R;

    void Update()
    {
        if (Input.GetKeyDown(teclaReset))
        {
            ResetearProgreso();
        }
    }

    void ResetearProgreso()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Debug.Log("Progreso de compras reiniciado");

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}