using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    int maxHealth;
    int currentHealth;
    [SerializeField]
    CharacterStats characterStats;
    

    public void SetMaxHealth()
    {

        maxHealth = characterStats.maxHealth.baseValue;
        slider.maxValue = maxHealth;
    }
    public void SetCurrentHealth()
    {
       
        currentHealth = characterStats.currentHealth;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        slider.value = currentHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
       
        SetMaxHealth();
       
        SetCurrentHealth();
        characterStats.OnHealthChange += CharacterStats_OnTookDamage;

    }

    private void CharacterStats_OnTookDamage(object sender, System.EventArgs e)
    {

        SetCurrentHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
