using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject HowToPlay;
    public GameObject backButton;

    public void PlayGamePressed()
    {
        SceneManager.LoadScene("1st_Level");
    }

    public void QuitGamePressed()
    {
        Application.Quit();
    }

    public void HowToPlayPressed()
    {
        backButton.SetActive(true);
        HowToPlay.SetActive(true);
    }

    public void BackButtonPressed()
    {
        backButton.SetActive(false);
        HowToPlay.SetActive(false);
    }

    public void MainMenuButtonPressed()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
