using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
