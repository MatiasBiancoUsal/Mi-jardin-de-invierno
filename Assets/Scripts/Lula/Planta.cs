using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Lula
{
    public class Planta : MonoBehaviour
    {
        public float Sol;
        public int Agua;
        public int Abono;
        public float TiempoFelicidad;
        public int ContadorFelicidad;
        public bool EnMantenimiento;

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
            Sol = 0f;
            Agua = 0;
            Abono = 0;
            ContadorFelicidad = 0;
            TiempoFelicidad = 0;

            ActualizarTextos();
        }

        public void SubirAgua()
        {
            if (Agua == AguaMaxima) return;
            if (!EnMantenimiento) return;

            Agua += 1;
            ActualizarTextos();
            CheckearFelicidad();
        }

        public void SubirAbono()
        {
            if (Abono == AbonoMaximo) return;
            if (!EnMantenimiento) return;

            Abono += 1;
            ActualizarTextos();
            CheckearFelicidad();
        }

        private void CheckearFelicidad()
        {
            if (Agua == AguaMaxima && Abono == AbonoMaximo && Sol == solMaximo)
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

                    // 👉 Sumamos pétalo automáticamente al contador
                    if (ContadorPetalo.instancia != null)
                        ContadorPetalo.instancia.SumarPetalo();

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
                ZonaDeSol zona = hit.collider.GetComponent<ZonaDeSol>();
                if (zona != null)
                {
                    SubirSolPorTiempo();
                }
            }

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

        private void SubirSolPorTiempo()
        {
            if (Sol < solMaximo)
            {
                Sol += velocidadGananciaSol * Time.deltaTime;
                Sol = Mathf.Min(Sol, solMaximo);
                CheckearFelicidad();
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
