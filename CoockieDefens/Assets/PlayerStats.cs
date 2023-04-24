using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStats : CharacterStats
{

    public event EventHandler OnPlayerDies;
 
   
    public override void Die()
    {
        OnPlayerDies?.Invoke(this, EventArgs.Empty);

        SetMaxHealth();
        gameObject.SetActive(false);
        
    }

 
    void SetMaxHealth()
    {
        currentHealth = maxHealth.GetValue();
        HealthChange_Event();

    }
   
   
    
}
