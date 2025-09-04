using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "NombreDeTuEscena"; // Cambialo por el nombre de la siguiente escena

    void Start()
    {
        // Cuando termina el video, se ejecuta OnVideoEnd
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
