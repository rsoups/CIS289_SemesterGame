using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseAI : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float aggroRange;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        distanceToPlayer();
    }

    void distanceToPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if(distance < aggroRange)
        {
            //chase code
            chasePlayer();
        }
        else
        {
            //stop chase
            stopChase();
        }
    }

    void chasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            //player is to the right, move right
            rb.velocity = new Vector2(speed, 0);

            transform.localScale = new Vector2(-2, 2);
        }
        else
        {
            //player is to the left, move left
            rb.velocity = new Vector2(-speed, 0);
            
            transform.localScale = new Vector2(2, 2);
        }
    }

    void stopChase()
    {
        rb.velocity = Vector2.zero;
    }
}
