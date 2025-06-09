using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayer(Vector3 position)
    {
        PlayerPrefs.SetFloat("posX", position.x);
        PlayerPrefs.SetFloat("posY", position.y);
        PlayerPrefs.SetFloat("posZ", position.z);
        PlayerPrefs.Save();
    }

    public static Vector3 LoadPlayer()
    {
        float x = PlayerPrefs.GetFloat("posX", 0);
        float y = PlayerPrefs.GetFloat("posY", 0);
        float z = PlayerPrefs.GetFloat("posZ", 0);
        return new Vector3(x, y, z);
    }

    public static bool HasSavedGame()
    {
        return PlayerPrefs.HasKey("posX");
    }
}
