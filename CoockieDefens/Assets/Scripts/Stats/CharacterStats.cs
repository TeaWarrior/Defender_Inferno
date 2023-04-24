using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat maxHealth;
    public int currentHealth { get;  set; }
    public Stat damage;
    public Stat armor; 
    public event EventHandler OnHealthChange;
    [SerializeField] GameObject popUpText_Prefab;
    public float colliderOffset;
    private void Awake()
    {
        currentHealth = maxHealth.GetValue();
    }
    private void Update()
    {
       
    }
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        GameObject damageText = Instantiate(popUpText_Prefab, transform.position+Vector3.up, Quaternion.identity);
        PopUpText popUpTextScript = damageText.GetComponent<PopUpText>();
        popUpTextScript.SetDamageText(damage);
        HealthChange_Event();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void HealthChange_Event()
    {
        OnHealthChange?.Invoke(this, EventArgs.Empty);
    }
    public virtual void Die()
    {
        Debug.Log(" dies");
        Destroy(gameObject);
    }
}

