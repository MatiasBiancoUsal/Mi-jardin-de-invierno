using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plantas : MonoBehaviour
{
    public bool generaSemillas;

    [Header("Necesidad: Agua")]
    public float AguaTotal;
    public float AguaNecesaria;
    public float aguaActual;

    [Header("Necesidad: Sol")]
    public float solTotal;
    public float solNecesario;
    public float solActual;


    [Header("Necesidad: Agua")]
    public float abonoTotal;
    public float abonoNecesario;
    public float abonoActual;


    [Header("Semillas")]
    public float TiempoTotalTimerSemillas;
    public float TimerSemillas;




    // Update is called once per frame
    protected virtual void Update()
    {
        aguaActual-=Time.deltaTime * 0.2f;
        solActual -= Time.deltaTime * 0.2f;
        abonoActual -= Time.deltaTime * 0.2f;



        generaSemillas = aguaActual > AguaNecesaria &&
                         solActual > solNecesario &&
                         abonoActual > abonoNecesario;


        if (true) ; // invierno
        else if (true) ;// verano
        else if (true) ;// otoño
        else if (true) funcionamientoPlantaInvierno() ;// primavera
    }

    protected virtual void funcionamientoPlantaInvierno()
    {
        // genasdasdasdasd
    }

    protected virtual void GenerarSemillas()
    {
        if(TimerSemillas>=TiempoTotalTimerSemillas)
        {
            TimerSemillas = 0;
            // GENERAR SEMILLAS
        }
        else
        {
            TimerSemillas += Time.deltaTime;
        }
    }




    protected void Regar()
    {
        if(aguaActual<AguaTotal)
            aguaActual += Time.deltaTime * 0.5f;
    }

    protected void Abonar()
    {

    }






}
