using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimarSemilla : MonoBehaviour
{
    private bool modoPlantar = false;

   
    public void ActivarModoPlantar()
    {
        modoPlantar = true;
        Debug.Log("Modo plantar activado. Haz clic en una maceta.");
    }

    void Update()
    {
        if (!modoPlantar || !Input.GetMouseButtonDown(0)) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Maceta"))
            {
                Transform maceta = hit.collider.transform;

                //Busca el gamebject SemillaPadre dentr de la maceta
                Transform semillaPadre = maceta.Find("SemillaPadre");
                Animator animSemilla = null;

                if (semillaPadre != null)
                {
                    animSemilla = semillaPadre.GetComponentInChildren<Animator>(true);
                    if (animSemilla != null)
                    {
                        if (!animSemilla.gameObject.activeSelf)
                            animSemilla.gameObject.SetActive(true);

                        animSemilla.Rebind();
                        animSemilla.Update(0f);
                        animSemilla.SetBool("ActivarAr", true);

                        StartCoroutine(AnimarPlantaLuego(animSemilla, maceta, 4f, 10f));
                    }
                    else
                    {
                        Debug.LogWarning("No se encontr Animator en SemillaPadre");
                    }
                }
                else
                {
                    Debug.LogWarning("No se encontr el objeto SemillaPadre dentro de la maceta");
                }

                modoPlantar = false;
            }
            else
            {
                Debug.Log("Eso no es una maceta. Toca una para plantar.");
            }
        }
    }

    private System.Collections.IEnumerator AnimarPlantaLuego(Animator animSemilla, Transform maceta, float durAnimSemilla, float delayPlanta)
    {
        yield return new WaitForSeconds(durAnimSemilla);

        animSemilla.SetBool("ActivarAr", false);
        animSemilla.gameObject.SetActive(false);

        yield return new WaitForSeconds(delayPlanta);

        //Busca el gamebject Semillaplanta dentro de la maceta
        Transform semillaPlanta = maceta.Find("Semillaplanta");
        Animator animPlanta = null;

        if (semillaPlanta != null)
        {
            animPlanta = semillaPlanta.GetComponentInChildren<Animator>(true);
            if (animPlanta != null)
            {
                if (!animPlanta.gameObject.activeSelf)
                    animPlanta.gameObject.SetActive(true);

                animPlanta.SetBool("ActivarPlanta", true);
            }
            else
            {
                Debug.LogWarning("No se encontr Animator en Semillaplanta");
            }
        }
        else
        {
            Debug.LogWarning("No se encontr el objeto Semillaplanta dentro de la maceta");
        }
    }
}