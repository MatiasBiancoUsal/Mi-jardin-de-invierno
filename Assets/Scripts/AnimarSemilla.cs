using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimarSemilla : MonoBehaviour
{
    private bool modoPlantar = false;

    
    public void ActivarModoPlantar()
    {
        modoPlantar = true;
        Debug.Log("Modo plantar activado. Hacé clic en una maceta.");
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

                // Buscar semilla inactiva dentro de la maceta
                Animator animSemilla = maceta.GetComponentInChildren<Animator>(true);
                if (animSemilla != null)
                {
                    GameObject semillaGO = animSemilla.gameObject;
                    semillaGO.SetActive(true);
                    semillaGO.transform.position = maceta.position + new Vector3(0, 0.1f, 0); 

                    animSemilla.Rebind();
                    animSemilla.Update(0f);
                    animSemilla.SetBool("ActivarAr", true);

                    StartCoroutine(DesactivarLuego(animSemilla, 4f));
                }
                else
                {
                    Debug.LogWarning("La maceta no tiene una semilla como hijo.");
                }

                modoPlantar = false; // Solo después de hacer clic en una maceta válida
            }
            else
            {
                Debug.Log("Eso no es una maceta. Tocá una para plantar.");
            }
        }
    }

    private System.Collections.IEnumerator DesactivarLuego(Animator anim, float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool("ActivarAr", false);
        anim.gameObject.SetActive(false);
    }
}