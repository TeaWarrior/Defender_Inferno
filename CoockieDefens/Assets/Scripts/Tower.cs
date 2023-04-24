using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : CharacterStats 
{
  
    public float range = 15f;
    public float attackSpeed=1f;
    public Transform target;
    public Transform partToRotate, aimPoint;
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCorotineStart)
        {
            StartCoroutine(SearchTargetCorotine());
        }
        if (target != null)
        {
            if (!isAttackCd)
            {
                StartCoroutine(Shoot());
                Rotate();
            }
            
        }
    }

    void Rotate()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    bool isCorotineStart;
    IEnumerator SearchTargetCorotine()
    {
        isCorotineStart = true;
        yield return new WaitForSeconds(0.5f);

        UpdateTarget();
        isCorotineStart = false;
    }
    bool isAttackCd;
    IEnumerator Shoot()
    {
        isAttackCd = true;
        GameObject bulletGO =  Instantiate(bulletPrefab, aimPoint.position, partToRotate.rotation);
        Bullet bulletScript = bulletGO.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.Seek(target);
            bulletScript.damage = damage.GetValue();
        }
        yield return new WaitForSeconds(attackSpeed);
        isAttackCd = false;
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy!=null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
