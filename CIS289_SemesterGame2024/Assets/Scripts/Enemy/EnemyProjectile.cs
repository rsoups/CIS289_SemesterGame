using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb;
    public PlayerHealth health;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
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
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(2);
            Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("Spell"))
        {
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }
}
