using UnityEngine;
using System.Collections;

public class BgmManager : MonoBehaviour {

    private static BgmManager instance = null;
    private AudioSource bgmAudioSource;
    private float bgmVolume;
    private bool mute = false;

    private string ppBgmVolume = "BgmVolume";
    private string ppMuteSounds = "MuteSounds";
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

        //Check if player already tune up the volume or not
        if (!PlayerPrefs.HasKey(ppBgmVolume))
        {
            PlayerPrefs.SetFloat(ppBgmVolume, 1f);
        }

        if (!PlayerPrefs.HasKey(ppMuteSounds))
        {
            PlayerPrefs.SetInt(ppMuteSounds, 0);
            mute = false;
        }
        else
        {
            if (PlayerPrefs.GetInt(ppMuteSounds) == 0)
                //if ppMuteSounds return 0 then mute
                mute = false;
            else
                //if not, ppMuteSounds should return 1 then
                mute = true;
        }

        bgmAudioSource = this.gameObject.GetComponent<AudioSource>();

        //to check the volume status when loading scene
        VolumeCheckUpdate();
    }

    //Used to check the mute/unmute and volume status when load another scene
    public void VolumeCheckUpdate()
    {
        if (mute)
        {
            MuteBgm();
        }
        else
        {
            bgmVolume = PlayerPrefs.GetFloat(ppBgmVolume);
            BgmVolume = bgmVolume;
        }
    }

    public float BgmVolume
    {
        get { return bgmAudioSource.volume; }
        set
        {
            bgmAudioSource.volume = value;
            PlayerPrefs.SetFloat(ppBgmVolume, value);
        }
    }

    public void MuteBgm()
    {
        bgmVolume = bgmAudioSource.volume;
        bgmAudioSource.volume = 0f;
        mute = true;
        PlayerPrefs.SetInt(ppMuteSounds, 1);
    }

    public void UnmuteBgm()
    {
        bgmAudioSource.volume = bgmVolume;
        mute = false;
        PlayerPrefs.SetInt(ppMuteSounds, 0);
    }
}