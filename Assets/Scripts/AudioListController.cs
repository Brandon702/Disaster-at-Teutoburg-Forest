using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioListController : MonoBehaviour
{
    private AudioSource BGM;
    private AudioSource SFX;

    public AudioSource[] MenuBGMClipArray;
    public AudioSource[] SFXClipArray;

    public AudioMixer mixer;

    public bool runOnce = false;

    private void Awake()
    {
        BGM = GetComponent<AudioSource>();
        SFX = GetComponent<AudioSource>();
    }
    public float GetBGM()
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
        //Following Problems:
        if(!(BGM.isPlaying) || BGM.clip == null)
        {
            runOnce = true;
        }

        //Main Menu
        if (GameController.Instance.state == eState.TITLE && runOnce == true)
        {
            BGM.clip = MenuBGMClipArray[Random.Range(0, MenuBGMClipArray.Length)].clip;
            BGM.PlayOneShot(BGM.clip, GetBGM());
            runOnce = false;
        }

        //Click
        //SFXSource.clip = SFXClipArray[0];
    }
}
