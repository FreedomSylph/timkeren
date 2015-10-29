using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    private AudioListener audioListener;

    void Awake()
    {
        //To adjust the camera size for responsive screen size
        float screenWidth = (float)Screen.width;
        float screenHeight = (float)Screen.height;
        float screenRatio = screenWidth / screenHeight;
        float camSize = 6.4f / screenRatio;
        Camera.main.orthographicSize = camSize;

        //Get the AudioSource
        audioListener = this.GetComponent<AudioListener>();
    }

    //to enable all sound by enabling audio listener
    public void EnableAudioListener()
    {
        audioListener.enabled = true;
    }

    //to mute all sound by disabling audio listener
    public void DisableAudioListener()
    {
        audioListener.enabled = false;
    }
}