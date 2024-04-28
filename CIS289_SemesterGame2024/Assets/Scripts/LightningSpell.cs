using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpell : MonoBehaviour
{
    public Animator animator;
    public Transform spellPos;
    public GameObject castSpell;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            spellAttack();
            Instantiate(castSpell, spellPos.position, spellPos.rotation);
        }
    }

    public void spellAttack()
    {
        animator.SetTrigger("Spell");
    }
}
