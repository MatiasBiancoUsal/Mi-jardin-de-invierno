using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Analytics
{
    class ClickComprarPlanta : MonoBehaviour
    {
        public string NombrePlanta;

        public void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            CustomEvent Datos = new CustomEvent("click_comprar_planta")
            {
                { "nombre_planta", NombrePlanta },
                { "semillas_suficientes", ContadorSemillas.instancia.TieneSemillasSuficientes() },
                { "nombre_nivel", SceneManager.GetActiveScene().name },
            };

            AnalyticsService.Instance.RecordEvent(Datos);
            AnalyticsService.Instance.Flush();
        }
    }
}
