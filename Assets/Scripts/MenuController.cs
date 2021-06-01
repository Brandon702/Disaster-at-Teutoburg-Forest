using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject MainMenuPanel;
    public GameObject OptionsPanel;
    public GameObject CreditsPanel;
    public GameObject PausePanel;
    public GameObject InstructionsPanel;
    public GameObject GamePanel;
    public GameObject ScenePanel;

    [Header("Sub-Panels")]
    //Maybe?

    [Header("Other")]
    public GameController gameController;
    List<GameObject> gameObjects = new List<GameObject>();
    public AudioMixer mixer;
    public AudioController audioController;

    private void Start()
    {
        gameObject.SetActive(true);
        gameObjects.Add(MainMenuPanel);
        gameObjects.Add(OptionsPanel);
        gameObjects.Add(CreditsPanel);
        gameObjects.Add(PausePanel);
        gameObjects.Add(InstructionsPanel);
        gameObjects.Add(GamePanel);
        gameObjects.Add(ScenePanel);

        Disable();
        MainMenuPanel.SetActive(true);
        GameController.Instance.state = eState.TITLE;
    }
    private void Update()
    {
        //if state is title & audio with certain tag is not playing, select a sound & play it
        if (GameController.Instance.state == eState.TITLE)
        {
            //Play either main menu sound track one or two
        }
    }

    private void OnEnable()
    {
        menuTrackPlayer();
    }

    private void menuTrackPlayer()
    {
        int trackPlay = UnityEngine.Random.Range(0, 1);
        if (trackPlay == 1)
        {
            audioController.Play("Track10");
            Debug.Log("Track 10 played");
        }
        else
        {
            audioController.Play("Track7");
            Debug.Log("Track 7 played");
        }
    }

    public void Disable()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
    }
    public void StartGame()
    {
        Disable();
        ScenePanel.SetActive(true);
        GameController.Instance.state = eState.GAME;
        Debug.Log("Start Game");
    }

    public void ResumeGame()
    {
        Disable();
        GamePanel.SetActive(true);
        GameController.Instance.state = eState.GAME;
        Debug.Log("Resume Game");
    }

    public void Options()
    {
        Disable();
        OptionsPanel.SetActive(true);
        Debug.Log("Options menu");
    }

    public void Instructions()
    {
        Disable();
        InstructionsPanel.SetActive(true);
        GameController.Instance.state = eState.INSTRUCTIONS;
    }

    public void Credits()
    {
        Disable();
        CreditsPanel.SetActive(true);
        Debug.Log("Credits menu");
    }

    public void Back()
    {
        Disable();

        if (GameController.Instance.state == eState.PAUSE)
        {
            BackToPause();
        }
        else
        {
            BackToMenu();
        }
    }

    public void Pause()
    {
        if (GameController.Instance.state == eState.GAME)
        {
            Disable();
            PausePanel.SetActive(true);
            GameController.Instance.state = eState.PAUSE;
        }
    }

    //Back to main menu
    public void BackToMenu()
    {
        Disable();
        MainMenuPanel.SetActive(true);
        GameController.Instance.state = eState.TITLE;
    }

    //Back to pause menu
    public void BackToPause()
    {
        Disable();
        PausePanel.SetActive(true);
        GameController.Instance.state = eState.PAUSE;
    }

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
    }

    public void ResetApplication()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}