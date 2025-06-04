using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Inventario : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
   
      public string sceneToLoad;

    
    public void LoadNewScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    
}
