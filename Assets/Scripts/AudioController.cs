<<<<<<< Updated upstream
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixer mixer;
    private string type;

    private void Awake()
    {

        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            type = s.audioType.ToString();
            s.source.outputAudioMixerGroup = mixer.FindMatchingGroups(type)[0];
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " does not exist");
            return;
        }
        s.source.Play();
=======
﻿using UnityEngine.Audio;
using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevelMST(float sliderValue)
    {
        mixer.SetFloat("MST", Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelBGM(float sliderValue)
    {
        mixer.SetFloat("BGM", Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelSFX(float sliderValue)
    {
        mixer.SetFloat("SFX", Mathf.Log10(sliderValue) * 20);
    }
    public void SetLevelPitch(float sliderValue)
    {
        mixer.SetFloat("Pitch", sliderValue);
    }


    public void Mute(bool mute)
    {
        if (mute) mixer.SetFloat("MST", -80);
        else mixer.SetFloat("MST", 0);
>>>>>>> Stashed changes
    }
}
