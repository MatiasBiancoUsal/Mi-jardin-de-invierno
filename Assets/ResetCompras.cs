using UnityEngine;

public class ResetCompras : MonoBehaviour
{
    [Header("Nombres de objetos comprables")]
    public string[] objetosComprables; // 

    public void ResetearSoloMacetas()
    {
        foreach (string nombre in objetosComprables)
        {
            PlayerPrefs.DeleteKey(nombre + "_Comprado"); // Estado de compra
            PlayerPrefs.DeleteKey(nombre + "_Crecido");  // Estado de crecimiento (si lo usás)
        }

        PlayerPrefs.Save();
        Debug.Log("Sistema de compras reiniciado (solo macetas)");
    }
}