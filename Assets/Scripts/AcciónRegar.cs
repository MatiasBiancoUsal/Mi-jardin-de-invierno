using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRegadera : MonoBehaviour
{
    public static MacetaRiego macetaSeleccionada;

    public void RegarMacetaSeleccionada()
    {
        if (macetaSeleccionada != null)
        {
            macetaSeleccionada.Regar();
        }
    }
}
