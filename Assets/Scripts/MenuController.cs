using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public void ResetApplication()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}