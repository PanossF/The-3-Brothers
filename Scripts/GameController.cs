using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{

    public GameObject Exit;
    public GameObject[] Enemies;
    public GameObject[] Loots;
    //Texts
    public Text blueTimeText;
    public Text RedTimeText;
    public Text RedShots;
    public Text loseText;

    public float blueTime = 5.0f;
    public float redTime = 5.0f;

    bool gameOver;
    bool blueCollected = false;
    bool escKeyPressed = false;

    //Times
    public float extraBlueTime = 7.0f;
    public float extraRedTime = 4.5f;
    float hasBlueTime = 1.0f;
    float hasRedTime = 1.0f;
    float elapsedBlueTime = 0.0f;
    float elapsedRedTime = 0.0f;

    int enemyKills = 0;
    int numberOfLoots = 0;

    //Gameobject scripts
    Player_Blue playerBlue;
    Player_Red playerRed;
    shotVelocity shot;
    UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        playerBlue = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Blue>();
        playerRed = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player_Red>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        gameOver = false;

    }


    void OnAwake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        CheckForEscape();
        //Time for blue character
        BlueTime();
        //Time for red character
        RedTimeAndShots();
        if(gameOver)
        {
            uiManager.ShowLosePanel();
            Time.timeScale = 0;
        }
    }

    void BlueTime()
    {
        if(hasBlueTime > 0 && !BlueHasCollectedAllLoots())
        {
            elapsedBlueTime += Time.deltaTime;
            hasBlueTime = blueTime - elapsedBlueTime;
        }
        else
        {
            //keep time fixed
            hasBlueTime = blueTime - elapsedBlueTime;
        }

        blueTimeText.text = "" + System.Math.Round(hasBlueTime, 2);
        if(hasBlueTime <= 0 && !playerBlue.HasBlueCollected())
        {
            elapsedBlueTime = 0.0f;
            uiManager.ReasonForLose("Blue Character has not collected all loots in given time");
            GameOver();
        }
        if(playerBlue.HasBlueCollected())
        {
            playerBlue.ResetLoot();
            blueTime += extraBlueTime;
            numberOfLoots++;
        }

        //warn player time is running low
        if(hasBlueTime < 2.0f)
        {
            blueTimeText.color = Color.red;
        }
        else
            blueTimeText.color = Color.white;
    }

    void RedTimeAndShots()
    {
        if (hasRedTime > 0 && !RedHasKilledAllEnemies())
        {
            elapsedRedTime += Time.deltaTime;
            hasRedTime = redTime - elapsedRedTime;
        }
        else
        {
            hasRedTime = redTime - elapsedRedTime; 
        }

        RedTimeText.text = "" + System.Math.Round(hasRedTime, 2);
        RedShots.text = "Available Shots: " + playerRed.NumberShots();
        if(hasRedTime <= 0 && !playerRed.HasKilledEnemy())
        {
            elapsedRedTime = 0.0f;
            uiManager.ReasonForLose("Gray Character has not killed all enemies in given time");
            GameOver();
        }
        if(playerRed.HasKilledEnemy())
        {
            playerRed.ResetKill();
            redTime += extraRedTime;
            enemyKills++;
        }

        //warn player time is running low
        if(hasRedTime < 2.0f)
        {
            RedTimeText.color = Color.red;
        }
        else
            RedTimeText.color = Color.white;

    }

    public bool RedHasKilledAllEnemies()
    {
        if ((Enemies.Length - enemyKills) == 0)
        {
            Exit.GetComponent<Renderer>().material.color = Color.green;
            return true;
        }
        else
            return false;
    }

    public bool BlueHasCollectedAllLoots()
    {
        if((Loots.Length - numberOfLoots) == 0)
        {
            return true;
        }
        else
            return false;
    }

    public void GameOver()
    {
        gameOver = true;
    }


    public void CheckForEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && escKeyPressed == false)
        {
            //esc key has been pressed once
            escKeyPressed = !escKeyPressed;
            uiManager.ShowPausePanel();
            Time.timeScale = 0;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escKeyPressed == true)
        {
            //make the esc key again false
            escKeyPressed = !escKeyPressed;
            uiManager.HidePausePanel();
            Time.timeScale = 1;
        }
    }

    

}
