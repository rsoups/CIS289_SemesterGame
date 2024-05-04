using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public int maxMana = 10;
    public int currentMana;

    public PlayerUI healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetMaxMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Debug.Log("You Died");
        }

        if(currentMana <= 0)
        {
            Debug.Log("Out of Mana");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void TakeMana(int mana)
    {
        currentMana -= mana;

        healthBar.SetMana(currentMana);
    }

    public void replenish(int amount)
    {
        currentMana += amount;
        healthBar.SetMana(currentMana);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Spikes"))
        {
            TakeDamage(1);
            //need to respawn to checkpoint as well

        }
    }
}
