using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salirdeljuego : MonoBehaviour
{
    public void Salir()
    {
       
        Application.Quit();

        //solo para chequear en el editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}