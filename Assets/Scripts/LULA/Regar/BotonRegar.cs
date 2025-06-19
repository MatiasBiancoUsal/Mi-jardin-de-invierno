using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Lula.Regar
{
    public class BotonRegar : MonoBehaviour
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
            plantas.CambiarModoRiego();
        }

        public void Update()
        {
            if (plantas.ModoRiego)
            {
                imagen.color = ColorPrendido;
            }
            else
            {
                imagen.color = ColorApagado;
            }
        }
    }
}
