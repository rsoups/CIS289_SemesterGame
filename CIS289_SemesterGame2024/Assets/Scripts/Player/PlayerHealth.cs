using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public int maxMana = 10;
    public int currentMana;
    public AudioClip hurtSoundClip;
    private AudioSource audioSource;

    public PlayerUI healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetMaxMana(maxMana);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }

        if(currentMana <= 0)
        {
            Debug.Log("Out of Mana");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        audioSource.clip = hurtSoundClip;
        audioSource.Play();

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
        }
    }
}
