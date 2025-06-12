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
        SceneManager.LoadScene("Invernadero");
    }

    public void IrASiguienteEscena()
    {
        int indiceActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indiceActual + 1);
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
