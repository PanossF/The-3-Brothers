using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotVelocity : MonoBehaviour
{

    Rigidbody2D rb;

    bool enemyShot = false;
    public float speed;
    Player_Red playerRed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        playerRed = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player_Red>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "enemy")
        {
            playerRed.HasHitEnemy();
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }


}
