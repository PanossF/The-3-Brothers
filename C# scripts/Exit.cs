using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    AudioSource audio;
    UIManager uiManager;

    int c = 0;

    void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3")
        {
            c++;
        }

        if (c == 3)
        {
            audio.Play();
            uiManager.ShowNextLevelPanel();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Player2")
        {
            c--;
        }
    }
}
