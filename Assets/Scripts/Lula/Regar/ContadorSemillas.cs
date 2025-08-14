using TMPro; // Usar 'TMPro' en lugar de 'TMP_Text' en el 'using'
using UnityEngine;

/// <summary>
/// Gestiona la cantidad de semillas en el juego.
/// Implementa el patrón de diseño Singleton para un acceso global y sencillo.
/// </summary>
public class ContadorSemillas : MonoBehaviour
{
    // --- Variables ---

    /// <summary>
    /// Instancia estática del Singleton para acceso global.
    /// </summary>
    public static ContadorSemillas instancia;

    [Header("Configuración UI")]
    [Tooltip("Referencia al componente TextMeshProUGUI que muestra el conteo de semillas.")]
    public TMP_Text textoContadorSemillas;

    // La variable es privada para que solo se pueda modificar a través de los métodos públicos.
    private int contadorSemillas = 0;

    // --- Métodos de Ciclo de Vida de Unity ---

    void Awake()
    {
        // Implementación del patrón Singleton.
        if (instancia == null)
        {
            instancia = this;
            // Opcional: Esto permite que el objeto persista al cambiar de escena.
            // Si no necesitas que persista, puedes eliminar esta línea.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existe otra instancia, la destruye para asegurar que solo haya una.
            Destroy(gameObject);
        }
    }

    // --- Métodos Públicos ---

    /// <summary>
    /// Incrementa el contador de semillas en uno y actualiza la UI.
    /// </summary>
    public void SumarSemilla()
    {
        contadorSemillas++;

        // Muestra el total de semillas en la consola de Unity para depuración.
        Debug.Log($"Semillas totales: {contadorSemillas}");

        // Llama al método que actualiza la UI para mantener el código más limpio.
        ActualizarTextoUI();
    }

    // --- Métodos Privados ---

    /// <summary>
    /// Actualiza el componente de texto en la UI con el valor actual de las semillas.
    /// </summary>
    private void ActualizarTextoUI()
    {
        // Verifica si la referencia al texto no es nula antes de intentar usarla.
        if (textoContadorSemillas != null)
        {
            textoContadorSemillas.text = $"{contadorSemillas}";
        }
    }
}