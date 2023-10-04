using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Red : MonoBehaviour
{
    public float speed = 3.0f;
    Rigidbody2D rb;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    bool hasHitEnemy = false;

    int numberShots = 0;
    int CounterShots = 0;

    Player_Blue playerBlue;
    GameController gameController;
    UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        rb = GetComponent<Rigidbody2D>();
        playerBlue = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Blue>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time > nextFire &&numberShots > 0)
        {
            CounterShots++;
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        numberShots = playerBlue.NumberOfLoots() - CounterShots;

        float moveVertical = 0.0f;
        float moveHorizontal = 0.0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveVertical = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveVertical = -1;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveHorizontal = -1;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveHorizontal = 1;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.velocity = movement * speed;

        Vector2 bounds = new Vector2(Mathf.Clamp(rb.position.x,-11.0f,11.0f),Mathf.Clamp(rb.position.y,-5.7f,5.7f));
        rb.position = bounds;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            uiManager.ReasonForLose("Gray Character has been killed");
            gameController.GameOver();
            //Destroy(gameObject);
        }
        if (other.tag == "Web")
        {
            uiManager.ReasonForLose("Gray Character has been caught on spider web");
            gameController.GameOver();
        }

    }

    public int NumberShots()
    {
        return numberShots;
    }

    public void HasHitEnemy()
    {
        hasHitEnemy = true;
    }

    public bool HasKilledEnemy()
    {
        if (hasHitEnemy == true)
        {
            return true;
        }
        else
            return false;
    }

    public void ResetKill()
    {
        hasHitEnemy = false;
    }
}

