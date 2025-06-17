using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Lula.Regar
{
    public class OcultarRegadera : MonoBehaviour
    {
        private SistemaDePlantas plantas;

        public void Start()
        {
            plantas = FindFirstObjectByType<SistemaDePlantas>();
        }

        public void Update()
        {
            gameObject.SetActive(plantas.ModoRiego);
        }
    }
}
