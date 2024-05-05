using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform spellPos;
    public SpellMovement castSpell;
    public float attackCooldown;
    public float castCooldown;
    float lastAttack;
    float lastCast;
    bool canCast = true;
    bool canAttack = true;
    //melee attack stuff
    public GameObject attackPoint;
    public float meleeRadius;
    public LayerMask enemies;
    public int meleeDamage;
    public int spellDamage;
    public PlayerHealth playerHealth;
    public PolygonCollider2D sword;
    public AudioClip slashSoundClip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        sword = GetComponent<PolygonCollider2D>();
        sword.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        attackCd();
        castCd();

        if(Input.GetButtonDown("Fire1"))
        {
            if(canAttack)
            {
                audioSource.clip = slashSoundClip;
                audioSource.Play();
                this.gameObject.tag = "Melee";
                animator.SetBool("isAttacking", true);
                sword.enabled = true;
            }
            canAttack = false;
        }

        if(Input.GetButtonDown("Fire2"))
        {
            if(canCast)
            {
                spellAttack();
            }
            canCast = false;
        }
    }

    public void basicAttack()
    {
        //animator.SetTrigger("Attack");

        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, meleeRadius, enemies);

        foreach (Collider2D enemyGameObject in enemy)
        {
            //Debug.Log("Hit Enemy");
            enemyGameObject.GetComponent<EnemyHealth>().currentHealth -= meleeDamage;
        }
    }

    public void spellAttack()
    {
        animator.SetTrigger("Spell");
        Instantiate(castSpell, spellPos.position, spellPos.rotation);
        playerHealth.TakeMana(2);
    }

    //this is used in the attack animation
    public void endAttack()
    {
        animator.SetBool("isAttacking", false);
        sword.enabled = false;
        this.gameObject.tag = "Player";
    }

    void attackCd()
    {
        if(lastAttack <= 0)
        {
            lastAttack = attackCooldown;
            canAttack = true;
        }
        else
        {
            lastAttack -= Time.deltaTime;
        }
    }

    void castCd()
    {
        if(lastCast <= 0)
        {
            lastCast = castCooldown;
            canCast = true;
        }
        else
        {
            lastCast -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, meleeRadius);
    }
}
