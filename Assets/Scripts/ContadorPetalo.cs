using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Lula
{
    public class NuevoContadorPetalo : MonoBehaviour
    {

        
        public TextMeshProUGUI counterText;

      
        public List<GameObject> petalsNeededList;

        // --- Variables Privadas ---
        private int currentPetals = 0;
        private int totalPetalsNeeded;

        // --- Singleton ---
        // Esto crea una referencia estática (global) a este script
        public static NuevoContadorPetalo Instance { get; private set; }

        private void Awake()
        {
            // Configuración del Singleton
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                // Si ya existe otro contador, destruye este
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            // Contamos cuántos pétalos pusiste en la lista
            totalPetalsNeeded = petalsNeededList.Count;

            // Inicializamos el contador en 0
            currentPetals = 0;
            UpdateCounterText();
        }

        // --- Métodos Públicos ---

        // Este método será llamado por cada pétalo cuando aparezca
        public void AddPetal()
        {
            currentPetals++;

            // Nos aseguramos de que no cuente más de lo necesario
            if (currentPetals > totalPetalsNeeded)
            {
                currentPetals = totalPetalsNeeded;
            }

            UpdateCounterText();

            // Opcional: Comprobar si ya ganaste
            if (currentPetals >= totalPetalsNeeded)
            {
                Debug.Log("¡Nivel completado! Tienes todos los pétalos.");
                // Aquí podrías llamar a una función de victoria
            }
        }

        // --- Métodos Privados ---

        // Método para actualizar el texto en la UI
        private void UpdateCounterText()
        {
            if (counterText != null)
            {
                counterText.text = $"{currentPetals} / {totalPetalsNeeded}";
            }
        }
    }
}

