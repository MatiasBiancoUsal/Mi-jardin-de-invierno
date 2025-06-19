using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Lula;
using UnityEngine;
using UnityEngine.UI;

public class BotonAbono : MonoBehaviour
{
    public Image imagen;
    public Color ColorPrendido = Color.green;
    public Color ColorApagado = Color.white;

    private SistemaDePlantas plantas;

    public void Awake()
    {
        plantas = FindFirstObjectByType<SistemaDePlantas>();
    }

    public void Click()
    {
        SistemaDePlantas.instancia.CambiarModoAbono();
    }

    public void Update()
    {
        if (SistemaDePlantas.instancia.ModoAbono)
        {
            imagen.color = ColorPrendido;
        }
        else
        {
            imagen.color = ColorApagado;
        }
    }
}
