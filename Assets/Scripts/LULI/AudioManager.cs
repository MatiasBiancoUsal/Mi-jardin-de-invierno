using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Serializable]
    public class Sonido
    {
        public string nombre;        // Nombre con el que llamás el sonido
        public AudioClip clip;       // El archivo de sonido
        [Range(0f, 1f)]
        public float volumen = 1f;
    }

    public Sonido[] sonidos;
    private AudioSource audioSource;

    void Awake()
    {
        // Singleton
        if (instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void ReproducirSonido(string nombre)
    {
        Sonido s = Array.Find(sonidos, sonido => sonido.nombre == nombre);
        if (s != null)
        {
            audioSource.PlayOneShot(s.clip, s.volumen);
        }
        else
        {
            Debug.LogWarning("No se encontró el sonido: " + nombre);
        }
    }
}
