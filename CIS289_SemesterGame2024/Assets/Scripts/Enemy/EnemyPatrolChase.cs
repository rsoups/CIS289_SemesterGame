using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolChase : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    Rigidbody2D rb;
    private Transform currentPoint;
    public Transform player;
    public Transform castPos;
    public float speed;
    public float aggroRange;
    bool playerInRange = false;
    public EnemyProjectile projectile;
    private float lastAttack = 0f; 
    public float cooldown;
    bool isFacingRight = true;
    public PlayerHealth health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer();

        //if player not in range, patrol
        if(!playerInRange)
        {
            Vector2 point = currentPoint.position - transform.position;
            if(currentPoint == pointB.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }

            if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
            {
                if(isFacingRight)
                {
                    flipSprite();
                }
                currentPoint = pointA.transform;
            }

            if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
            {
                if(!isFacingRight)
                {
                    flipSprite();
                }
                currentPoint = pointB.transform;
            }
        }
    }

    void flipSprite()
    {
        // Vector3 localScale = transform.localScale;
        // localScale.x *= -1;
        // transform.localScale = localScale;

        isFacingRight = !isFacingRight;
        transform.Rotate(new Vector3(0, 180, 0));
    }

    void engage()
    {
        //player is to the right
        if(transform.position.x < player.position.x)
        {
            playerInRange = true;
            rb.velocity = Vector2.zero;
            if(!isFacingRight)
            {
                isFacingRight = true;
                transform.Rotate(new Vector3(0, 180, 0));
            }
            enemyShoot();
        }
        //player is to the left
        else if(transform.position.x > player.position.x)
        {
            playerInRange = true;
            rb.velocity = Vector2.zero;
            if(isFacingRight)
            {
                isFacingRight = false;
                transform.Rotate(new Vector3(0, 180, 0));
            }
            enemyShoot();
        }
        //player has gone out of range, back to patrol
        else
        {
            playerInRange = false;
            if(isFacingRight && currentPoint == pointA.transform || !isFacingRight && currentPoint == pointB.transform)
            {
                isFacingRight = !isFacingRight;

                transform.Rotate(new Vector3(0f, 180f, 0f));
            }
        }
    }

    void distanceToPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if(distance < aggroRange)
        {
            //chase code
            engage();
        }
        else
        {
            //stop chase
            playerInRange = false;
            if(isFacingRight && currentPoint == pointA.transform || !isFacingRight && currentPoint == pointB.transform)
            {
                isFacingRight = !isFacingRight;

                transform.Rotate(new Vector3(0f, 180f, 0f));
            }
        }
    }

    void enemyShoot()
    {
       if(lastAttack <= 0)
        {
            lastAttack = cooldown;
            Instantiate(projectile, castPos.position, castPos.rotation);
        }
        else
        {
            lastAttack -= Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
