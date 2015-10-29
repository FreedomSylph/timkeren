using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public AudioListener audioListener;

    public GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        //To make sure this gameobject doesn't move on reloading scene
        this.transform.position = Vector3.zero;

        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //get the audio listener from the Main Camera
        //audioListener = GameObject.FindObjectOfType<AudioListener>();
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