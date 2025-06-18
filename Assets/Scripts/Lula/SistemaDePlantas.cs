using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Lula
{
    public class SistemaDePlantas : MonoBehaviour
    {
        public static SistemaDePlantas instancia;

        public bool ModoRiego;
        public bool ModoLuz;
        public bool ModoAbono;

        public GameObject contadorAguaGO;
        public GameObject contadorAbonoGO;


        public void Awake()
        {
            ModoAbono = false;
            ModoLuz = false;
            ModoRiego = false;
            instancia = this;
        }

        public void CambiarModoRiego()
        {
            ModoRiego = !ModoRiego;
            ModoAbono = false;
            ModoLuz = false;

            if (contadorAguaGO != null)
                contadorAguaGO.SetActive(ModoRiego);

            if (contadorAbonoGO != null)
                contadorAbonoGO.SetActive(false);
        }

        public void CambiarModoAbono()
        {
            ModoAbono = !ModoAbono;
            ModoRiego = false;
            ModoLuz = false;

            if (contadorAbonoGO != null)
                contadorAbonoGO.SetActive(ModoAbono);

            if (contadorAguaGO != null)
                contadorAguaGO.SetActive(false);
        }
    }
}
