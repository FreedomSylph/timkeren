using UnityEngine;
using System.Collections;

public class BgmManager : MonoBehaviour {

    private static BgmManager instance = null;
    private AudioSource bgmAudioSource;

    public BgmManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        //-------------Singleton method--------------------------//
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy instance. This enforces new bgm on current scene.
            Destroy(instance.gameObject);

            //set instance to this new bgm manager until destroyed again
            instance = this;
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //--------------Singleton finished-----------------------//

        bgmAudioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public float BgmVolume
    {
        get { return bgmAudioSource.volume; }
        set { bgmAudioSource.volume = value; }
    }
}