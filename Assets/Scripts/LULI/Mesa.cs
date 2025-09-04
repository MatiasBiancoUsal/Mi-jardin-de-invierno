using UnityEngine;

public class Mesa : MonoBehaviour
{
    public static event System.Action OnPlantaEnMesa;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Planta"))
        {
            // Aseguramos que se pegó al punto
            Transform puntoDisponible = BuscarPuntoDisponible();

            if (puntoDisponible != null)
            {
                other.transform.position = puntoDisponible.position;
                other.transform.rotation = puntoDisponible.rotation;
                other.transform.SetParent(puntoDisponible);

                Debug.Log("Planta colocada en la mesa");

                // Lanza el evento para el tutorial
                OnPlantaEnMesa?.Invoke();
            }
        }
    }

    private Transform BuscarPuntoDisponible()
    {
        foreach (Transform hijo in transform)
        {
            if (hijo.name.Contains("puntoParaPlanta") && hijo.childCount == 0)
            {
                return hijo; // Devuelve el primer punto vacío
            }
        }
        return null;
    }
}
