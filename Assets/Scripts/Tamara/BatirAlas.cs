using UnityEngine;

public class BatirAlas : MonoBehaviour
{
    public Transform alaIzquierda1;
    public Transform alaIzquierda2;
    public Transform alaDerecha1;
    public Transform alaDerecha2;

    public float velocidad = 20f; // velocidad del batido
    public float amplitud = 30f;  // cuánto se mueven las alas

    private Quaternion rotacionBaseIzq1;
    private Quaternion rotacionBaseIzq2;
    private Quaternion rotacionBaseDer1;
    private Quaternion rotacionBaseDer2;

    void Start()
    {
        // Guardamos la rotación original para no perderla
        rotacionBaseIzq1 = alaIzquierda1.localRotation;
        rotacionBaseIzq2 = alaIzquierda2.localRotation;
        rotacionBaseDer1 = alaDerecha1.localRotation;
        rotacionBaseDer2 = alaDerecha2.localRotation;
    }

    void Update()
    {
        float angulo = Mathf.Sin(Time.time * velocidad) * amplitud;

        alaIzquierda1.localRotation = rotacionBaseIzq1 * Quaternion.Euler(angulo, 0, 0);
        alaIzquierda2.localRotation = rotacionBaseIzq2 * Quaternion.Euler(angulo, 0, 0);

        alaDerecha1.localRotation = rotacionBaseDer1 * Quaternion.Euler(-angulo, 0, 0);
        alaDerecha2.localRotation = rotacionBaseDer2 * Quaternion.Euler(-angulo, 0, 0);
    }
}
