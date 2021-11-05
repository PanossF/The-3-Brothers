using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Blue : MonoBehaviour
{
    public float speed = 3.0f;
    Rigidbody2D rb;
    bool blue_Loot = false;
    int loot = 0;
    public int lootToGive = 2;

    AudioSource audio;

    GameController gameController;
    UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveVertical = 0.0f;
        float moveHorizontal = 0.0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -1;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;

        Vector2 bounds = new Vector2(Mathf.Clamp(rb.position.x, -11.0f, 11.0f), Mathf.Clamp(rb.position.y, -5.7f, 5.7f));
        rb.position = bounds;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Blue_Loot")
        {
            Destroy(other.gameObject);
            audio.Play();
            blue_Loot = true;
            loot+=lootToGive;
        }

        if (other.tag == "enemy")
        {
            uiManager.ReasonForLose("Blue Character has been killed");
            gameController.GameOver();
            //Destroy(gameObject);
        }

        if (other.tag == "Web")
        {
            uiManager.ReasonForLose("Blue Character has been caught on spider web");
            gameController.GameOver();
        }
    }

    public bool HasBlueCollected()
    {
        if (blue_Loot)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int NumberOfLoots()
    {
        return loot;
    }

    public void ResetLoot()
    {
        blue_Loot = false;
    }
}
