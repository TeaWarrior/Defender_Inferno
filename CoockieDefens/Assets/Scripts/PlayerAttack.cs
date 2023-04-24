using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    Transform attackPoint;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField] string enemyTag;
   [SerializeField] CharacterStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = gameObject.GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
          
        }
    }
    void Attack()
    {
        Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
        SimpleBullet simple = bulletPrefab.GetComponent<SimpleBullet>();
        simple.SetDamage(playerStats.damage.GetValue());
    }
}
