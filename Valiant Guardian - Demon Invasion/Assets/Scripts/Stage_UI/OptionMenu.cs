using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//this class must be attached to OptionBoard gameobject

public class OptionMenu : MonoBehaviour {

    private GameManager gameManager;
    private CameraManager camManager;
    private BgmManager bgmManager;

    private GameObject optionBoard;

    //these slider used to change the volume
    private Slider bgmSlider;
    private Slider sfxSlider;

    private Image muteAllSoundsImage;
    public Sprite[] muteAllSoundsSprite = new Sprite[2];

    void Awake()
    {
        optionBoard = this.gameObject;
        muteAllSoundsImage = this.gameObject.transform.Find("MuteBtn").GetComponent<Image>();

        bgmSlider = transform.FindChild("Slider").FindChild("BgmSlider").GetComponent<Slider>();
        sfxSlider = transform.FindChild("Slider").FindChild("SfxSlider").GetComponent<Slider>();
    }

    void Start()
    {
        CloseOptionBoard();

        gameManager = ScriptableObject.FindObjectOfType<GameManager>();
        camManager = ScriptableObject.FindObjectOfType<CameraManager>();
        bgmManager = ScriptableObject.FindObjectOfType<BgmManager>();
    }

    public void OpenOptionBoard()
    {
        optionBoard.SetActive(true);
    }

    public void CloseOptionBoard()
    {
        optionBoard.SetActive(false);
    }

    //called from mute button
    public void ToogleMuteAllSoundsBtn()
    {
        if(muteAllSoundsImage.sprite == muteAllSoundsSprite[0])
        {
            muteAllSoundsImage.sprite = muteAllSoundsSprite[1];
            //gameManager.Instance.DisableAudioListener();
            camManager.DisableAudioListener();
        }
        else
        {
            muteAllSoundsImage.sprite = muteAllSoundsSprite[0];
            //gameManager.Instance.EnableAudioListener();
            camManager.EnableAudioListener();
        }
    }

    //this method called from BgmSlider when it changed
    public void UpdateBgmVolume()
    {
        float bgmVolume = bgmSlider.value;
        bgmManager.Instance.BgmVolume = bgmVolume;
    }

    //this method called from SfxSlider when it changed
    public void UpdateSfxVolume()
    {

    }
}