using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Lula
{
    public class Planta : MonoBehaviour
    {
        public int Luz;
        public int Agua;
        public int Abono;
        public float TiempoFelicidad;
        public int ContadorFelicidad;
        public bool EnMantenimiento;

        public int LuzMaxima;
        public int AguaMaxima;
        public int AbonoMaximo;
        public int FelicidadMaxima;
        public float DuracionFelicidad;

        public TMP_Text textoAgua;
        public TMP_Text textoAbono;

        public GameObject Semilla;

        public void Start()
        {
            Luz = 0;
            Agua = 0;
            Abono = 0;
            ContadorFelicidad = 0;
            TiempoFelicidad = 0;
        }

        public void SubirAgua()
        {
            if (EstaFeliz()) return;
            if (Agua == AguaMaxima) return;
            if (!EnMantenimiento) return;

            Agua += 1;
            ActualizarTextos();
            CheckearFelicidad();
        }

        public void SubirAbono()
        {
            if (EstaFeliz()) return;
            if (Abono == AbonoMaximo) return;
            if (!EnMantenimiento) return;

            Abono += 1;
            ActualizarTextos();
            CheckearFelicidad();

        }

        public void SubirLuz()
        {
            if (EstaFeliz()) return;
            if (Luz == LuzMaxima) return;

            if (!EnMantenimiento) return;

            Luz += 1;
            CheckearFelicidad();
        }

        private void CheckearFelicidad()
        {
            if (Agua == AguaMaxima && Abono == AbonoMaximo)
            {
                ContadorFelicidad += 1;
                TiempoFelicidad = DuracionFelicidad;
                Semilla.SetActive(true);
                EnMantenimiento = false;
            }
        }

        public void Update()
        {
            if (EstaFeliz()) return;
            if (EnMantenimiento) return;

            TiempoFelicidad -= Time.deltaTime;
            if (TiempoFelicidad <= 0)
            {
                TiempoFelicidad = 0;
                Agua = 0;
                Abono = 0;
                Luz = 0;
                EnMantenimiento = true;

                ActualizarTextos();
            }
        }

        void ActualizarTextos()
        {
            if (textoAgua != null)
                textoAgua.text = $"{Agua}/{AguaMaxima}";

            if (textoAbono != null)
                textoAbono.text = $"{Abono}/{AbonoMaximo}";

        }

        public bool TieneFelicidad()
        {
            return ContadorFelicidad > 0 && !EnMantenimiento;
        }


        public bool EstaFeliz()
        {
            return ContadorFelicidad == FelicidadMaxima;
        }
    }
}
