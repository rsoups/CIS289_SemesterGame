using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMovement : MonoBehaviour
{
    public float speed = 6f;
    public Rigidbody2D rb;
    public float counter = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;

        if(counter <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(3);
            Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(this.gameObject);
        }
        
        //Destroy(this.gameObject);
    }
}
