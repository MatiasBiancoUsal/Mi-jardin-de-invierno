using UnityEngine;

public class MostrarMaceta : MonoBehaviour
{
    public string nombreObjeto;    
    public GameObject maceta;       

    void Start()
    {
        if (PlayerPrefs.GetInt(nombreObjeto + "_Comprado", 0) == 1)
        {
            if (maceta != null)
                maceta.SetActive(true);
        }
        else
        {
            if (maceta != null)
                maceta.SetActive(false);
        }
    }
}