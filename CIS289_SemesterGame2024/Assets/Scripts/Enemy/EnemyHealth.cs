using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    Rigidbody2D rb;
    public PlayerHealth manaBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }

        // if(currentHealth < maxHealth)
        // {
        //     rb.transform.position += transform.forward * Time.deltaTime * force;
        // }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    void Die()
    {
        Debug.Log("Enemy died");

        int replenish = Random.Range(2,4);

        manaBar.replenish(replenish);

        Destroy(this.gameObject);
    }
}
