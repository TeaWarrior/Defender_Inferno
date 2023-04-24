using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : CharacterStats,IDamagable
{
    [SerializeField]
    int treeHealth;
    [SerializeField]
    int woodPerDamageAmount;
    [SerializeField] Animator animator;
    

    public override void TakeDamage(int damage)
    {
        animator.Play("TreeDamage");
        int healthBeforeDamager= currentHealth;
       
        Debug.Log(damage);
        currentHealth -= damage;
        if (currentHealth / 10 < healthBeforeDamager / 10)
        {
            int woodAmount = healthBeforeDamager / 10 - currentHealth / 10;
            GiveWood(woodAmount);
        }

        if (currentHealth <= 0)
        {
            GiveWood(1);
            Die();
        }


    }

    void GiveWood(int woodAmount)
    {
       
        ResourcesManager.instance.AddWood(woodAmount);
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
