using UnityEngine;

public class TutorialEventos : MonoBehaviour
{
    // Referencia al gestor del tutorial
    public TutorialManager tutorialManager;

    // Llamado por la animación con un Animation Event
    public void RegadoTerminado()
    {
        if (tutorialManager != null)
        {
            // Llama a RegistrarAccion y le pasas el nombre de la acción que se completó.
            // Asegúrate de que este string coincida con el que pusiste en el Inspector de Unity
            // en el campo 'Accion Esperada' del paso correspondiente.
            tutorialManager.RegistrarAccion("regar");
        }
        else
        {
            Debug.LogWarning("TutorialManager no está asignado en TutorialEventos");
        }
    }

    public void AbonoTerminado()
    {
        if (tutorialManager != null)
        {
            // Llama a RegistrarAccion y le pasas el nombre de la acción que se completó.
            // Asegúrate de que este string coincida con el que pusiste en el Inspector de Unity
            // en el campo 'Accion Esperada' del paso correspondiente.
            tutorialManager.RegistrarAccion("abono");
        }
        else
        {
            Debug.LogWarning("TutorialManager no está asignado en TutorialEventos");
        }
    }

    public void PlantadoTerminado()
    {
        if (tutorialManager != null)
        {
            // Llama a RegistrarAccion y le pasas el nombre de la acción que se completó.
            // Asegúrate de que este string coincida con el que pusiste en el Inspector de Unity
            // en el campo 'Accion Esperada' del paso correspondiente.
            tutorialManager.RegistrarAccion("plantar");
        }
        else
        {
            Debug.LogWarning("TutorialManager no está asignado en TutorialEventos");
        }
    }
    
    public void PetaloTerminado()
    {
        if (tutorialManager != null)
        {
            // Llama a RegistrarAccion y le pasas el nombre de la acción que se completó.
            // Asegúrate de que este string coincida con el que pusiste en el Inspector de Unity
            // en el campo 'Accion Esperada' del paso correspondiente.
            tutorialManager.RegistrarAccion("petalo"); 
        }
        else
        {
            Debug.LogWarning("TutorialManager no está asignado en TutorialEventos");
        }
    }
}