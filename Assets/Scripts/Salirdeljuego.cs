using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salirdeljuego : MonoBehaviour
{
    void Update()
    {
        // Detectar si se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        // Esto funciona en el build
        Application.Quit();

        // Esto solo funciona en el editor (opcional para pruebas)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
