using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private static AudioListener audioListener;

    void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    //to enable all sound by enabling audio listener
    public static void EnableAudioListener()
    {
        if (audioListener == null)
        {
            audioListener = GameObject.Find("Main Camera").GetComponent<AudioListener>();
        }
        audioListener.enabled = true;
    }

    //to mute all sound by disabling audio listener
    public static void DisableAudioListener()
    {
        if (audioListener == null)
        {
            audioListener = GameObject.Find("Main Camera").GetComponent<AudioListener>();
        }
        audioListener.enabled = false;
    }
}