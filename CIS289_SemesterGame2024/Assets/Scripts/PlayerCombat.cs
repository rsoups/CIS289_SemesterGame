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
    public PlayerMovement playerMovement;
    public float attackCooldown;
    public float castCooldown;
    float lastAttack;
    float lastCast;
    bool canCast = true;
    bool canAttack = true;

    // Update is called once per frame
    void Update()
    {
        attackCd();
        castCd();

        if(Input.GetButtonDown("Fire1"))
        {
            if(canAttack)
            {
                basicAttack();
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
        animator.SetTrigger("Attack");
    }

    public void spellAttack()
    {
        animator.SetTrigger("Spell");
        Instantiate(castSpell, spellPos.position, spellPos.rotation);
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

}
