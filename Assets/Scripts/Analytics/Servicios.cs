using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class Servicios : MonoBehaviour
{

    async void Start()
    {
        await UnityServices.InitializeAsync();

        AnalyticsService.Instance.StartDataCollection();
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

