using UnityEngine;

public class BotonGuardar : MonoBehaviour
{
    public PlantaInteractable plantaActual;

    public void Guardar()
    {
        if (plantaActual != null)
        {
            plantaActual.GuardarEnInventario();
        }

        
    }
}
