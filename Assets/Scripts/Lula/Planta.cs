using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Lula
{
    public class Planta : MonoBehaviour
    {
        public int Sol;
        public int Agua;
        public int Abono;
        public float TiempoFelicidad;
        public int ContadorFelicidad;
        public bool EnMantenimiento;

        public GameObject particulasRosas;

        //public int SolMaxima;
        public int AguaMaxima;
        public int AbonoMaximo;
        public int FelicidadMaxima = 3;
        public float DuracionFelicidad;

        public TMP_Text textoAgua;
        public TMP_Text textoAbono;

        public GameObject Semilla;

        public GameObject Petalo;               
        private bool yaTiroPetalo = false;

        public float cantidadDeSol = 0f;
        public float solMaximo = 100f;
        public float velocidadGananciaSol = 5f; // Cuánto sol gana por segundo


        public void Start()
        {
            Sol = 0;
            Agua = 0;
            Abono = 0;
            ContadorFelicidad = 0;
            TiempoFelicidad = 0;

            ActualizarTextos();
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

        public void SubirSol()
        {
            if (EstaFeliz()) return;
            if (Sol == solMaximo) return;

            if (!EnMantenimiento) return;

            Sol += 1;
            CheckearFelicidad();
        }

        private void CheckearFelicidad()
        {
            if (Agua == AguaMaxima && Abono == AbonoMaximo)
            {
                // Planta entra en estado de felicidad
                ContadorFelicidad++;
                TiempoFelicidad = DuracionFelicidad;
                EnMantenimiento = false;

                // Tira semilla si tiene una
                if (Semilla != null)
                    Semilla.SetActive(true);

                // Si alcanza la felicidad máxima y aún no tiró el pétalo
                if (ContadorFelicidad >= FelicidadMaxima && !yaTiroPetalo)
                {
                    yaTiroPetalo = true;

                    if (Petalo != null)
                        Petalo.SetActive(true);

                    if (particulasRosas != null)
                        particulasRosas.SetActive(false);

                    Debug.Log("🌸 La planta alcanzó su FELICIDAD MÁXIMA. ¡Pétalo activado!");
                }


            }
        }

        public void Update()
        {

            Debug.DrawRay(transform.position + Vector3.up * 0.1f, Vector3.down * 2f, Color.yellow);

            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit, 2f))
            {
                Debug.Log("Raycast tocó: " + hit.collider.name);

                ZonaDeSol zona = hit.collider.GetComponent<ZonaDeSol>();
                if (zona != null)
                {
                    Debug.Log("Zona de sol detectada");

                    if (Sol < solMaximo)
                    {
                        Debug.Log("Sumando sol...");
                        Sol += Mathf.RoundToInt(velocidadGananciaSol * Time.deltaTime);
                        Sol = Mathf.Min(Sol, (int)solMaximo);
                        ActualizarTextos();
                    }
                }
            }

            if (EstaFeliz()) return;
            if (EnMantenimiento) return;

            TiempoFelicidad -= Time.deltaTime;
            if (TiempoFelicidad <= 0)
            {
                TiempoFelicidad = 0;
                Agua = 0;
                Abono = 0;
                Sol = 0;
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
