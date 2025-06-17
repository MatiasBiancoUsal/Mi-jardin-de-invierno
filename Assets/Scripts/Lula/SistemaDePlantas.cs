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
        }

        public void CambiarModoAbono()
        {
            ModoAbono = !ModoAbono;
            ModoRiego = false;
            ModoLuz = false;
        }
    }
}
