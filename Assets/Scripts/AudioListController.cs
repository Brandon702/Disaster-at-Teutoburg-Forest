using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioListController : MonoBehaviour
{
    private AudioSource BGMSource;
    private AudioSource SFXSource;

    public AudioClip[] MenuBGMClipArray;
    public AudioClip[] SFXClipArray;

    public AudioMixer mixer;

    public bool runOnce = false;

    private void Awake()
    {
        BGMSource = GetComponent<AudioSource>();
        SFXSource = GetComponent<AudioSource>();
    }

    public float GetBGMVol()
    {
        float value;
        bool result = mixer.GetFloat("BGM", out value);
        if (result)
        {
            return value;
        }
        else
        {
            return 0f;
        }
    }

    private void Update()
    {
        if(GetBGMVol() == -80f)
        {
            //runOnce = true;
        }

        //Main Menu
        if (GameController.Instance.state == eState.TITLE && runOnce == true)
        {
            BGMSource.clip = MenuBGMClipArray[Random.Range(0, MenuBGMClipArray.Length)];
            BGMSource.PlayOneShot(BGMSource.clip);
            runOnce = false;
        }


        //Click
        //SFXSource.clip = SFXClipArray[0];
    }
}
