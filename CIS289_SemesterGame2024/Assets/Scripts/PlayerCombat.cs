using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform spellPos;
    public GameObject castSpell;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            basicAttack();
        }

        if(Input.GetButtonDown("Fire2"))
        {
            spellAttack();
            Instantiate(castSpell, spellPos.position, spellPos.rotation);
        }

    }

    public void basicAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void spellAttack()
    {
        animator.SetTrigger("Spell");
    }
}
