using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonesrochi : MonoBehaviour
{
    public string nivelTienda;
    public string intro;

    public void EscenaJuego()

    {
        SceneManager.LoadScene(nivelTienda);

    }

    public void Intro()

    {
        SceneManager.LoadScene(intro);

    }





}
