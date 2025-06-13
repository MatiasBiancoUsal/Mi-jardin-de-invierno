using UnityEngine;

public class UIInventario : MonoBehaviour
{
    public static bool inventarioAbierto = false;
    public GameObject panelInventario;

    public void AlternarInventario()
    {
        inventarioAbierto = !inventarioAbierto;
        panelInventario.SetActive(inventarioAbierto);
    }
}
