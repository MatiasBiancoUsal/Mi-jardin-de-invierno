using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Lula;
using UnityEngine;

namespace Assets.Scripts.Lula.Regar
{
    public class OcultarAbono : MonoBehaviour
    {
        private SistemaDePlantas plantas;

        public void Start()
        {
            plantas = FindFirstObjectByType<SistemaDePlantas>();
        }

        public void Update()
        {
            gameObject.SetActive(plantas.ModoAbono);
        }
    }
}
