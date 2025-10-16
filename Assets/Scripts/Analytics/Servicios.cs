using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class Servicios : MonoBehaviour
{
    private static Servicios Singletone;

    async void Start()
    {
        await UnityServices.InitializeAsync();

        AnalyticsService.Instance.StartDataCollection();
    }

    private void Awake()
    {
        if (Singletone == null!)
        {
            Singletone = this;
        }

        else Destroy(gameObject);

    }

}


//public void DatosEventos
 //   {

//        CustomEvento Datos = new CustomEvent("ExactamenteElNombreDelEvento")
 //       {

 //           ("ExactamenteElNombreDelEvento", "NombredelavariabledelDato");

 //           ("ExactamenteElNombreDelEvento" , 3);

//        }
//        AnalitycsService.Instance.RecordEvento(Datos);
//        AnalyticsService,Instance.Flush();

//    } 

