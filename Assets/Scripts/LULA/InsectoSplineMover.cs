using UnityEngine;
using System.Collections;
using UnityEngine.Splines;

public class InsectoSplineMover : MonoBehaviour
{
    public Transform[] splinePoints; // puntos del spline
    public float speed = 2f;         // velocidad
    private int currentIndex = 0;

    void Start()
    {
        if (splinePoints.Length > 0)
            transform.position = splinePoints[0].position;
    }

    void Update()
    {
        if (splinePoints.Length < 2) return;

        // moverse hacia el siguiente punto
        Vector3 target = splinePoints[currentIndex + 1].position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // girar hacia el objetivo
        Vector3 direction = target - transform.position;
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);

        // si llegó al punto siguiente
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            currentIndex++;
            if (currentIndex >= splinePoints.Length - 1)
                currentIndex = 0; // reinicia el recorrido
        }
    }
}

