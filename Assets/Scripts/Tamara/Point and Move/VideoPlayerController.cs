using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    // Arrastra el componente Video Player aquí en el Inspector
    public VideoPlayer videoPlayer;

    private bool isMuted = false;

    // Esta función será llamada por el botón
    public void ToggleMute()
    {
        // Cambia el estado de mute
        isMuted = !isMuted;

        // Si el video tiene al menos una pista de audio, la muteamos
        if (videoPlayer.audioTrackCount > 0)
        {
            videoPlayer.SetDirectAudioMute(0, isMuted);
        }
        else
        {
            Debug.LogWarning("El Video Player no tiene pistas de audio.");
        }
    }
}
