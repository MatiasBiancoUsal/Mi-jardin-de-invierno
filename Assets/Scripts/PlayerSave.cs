using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    void Start()
    {
        if (SaveSystem.HasSavedGame())
        {
            transform.position = SaveSystem.LoadPlayer();
        }
    }

    public void SaveGame()
    {
        SaveSystem.SavePlayer(transform.position);
        Debug.Log("Partida guardada.");
    }

    public void LoadGame()
    {
        if (SaveSystem.HasSavedGame())
        {
            transform.position = SaveSystem.LoadPlayer();
            Debug.Log("Partida cargada.");
        }
    }
}
