using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class botones : MonoBehaviour
{

public Button semillas;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       public void EscenaJuego()

    {
        SceneManager.LoadScene("Intro");
    }

    public void CargarNivel(string NombreNivel)

    {
        SceneManager.LoadScene(NombreNivel);
    }

    
    public void BotonAñadido()
    {
        semillas.gameObject.SetActive(false);
    }

}
