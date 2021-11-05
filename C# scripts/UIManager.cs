using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public string currentScene;
    public string nextScene;

    public GameObject pausePanel;
    public GameObject mainMenuButton;

    public GameObject losePanel;
    public GameObject restartButton;

    public GameObject nextLevelPanel;
    public GameObject nextLevelButton;

    public Text loseText;

    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
        mainMenuButton.SetActive(true);
    }

    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
        mainMenuButton.SetActive(false);
    }

    public void MainMenuButtonPressed()
    {
        SceneManager.LoadScene("Main_Menu");
        Time.timeScale = 1;
    }

    public void ReasonForLose(string lose_text)
    {
        loseText.text = lose_text;
    }

    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
        restartButton.SetActive(true);
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void ShowNextLevelPanel()
    {
        nextLevelPanel.SetActive(true);
        nextLevelButton.SetActive(true);
    }

    public void NextLevelButtonPressed()
    {
        SceneManager.LoadScene(nextScene);
    }
}
