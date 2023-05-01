using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAI : CharacterStats,IDamagable
{


   
    private Transform pointToGo;
    public Transform target;
    public string enemyTag = "Player";
    public float attackRange = 10f;
    public float chaseRange = 10f;
    public float fireRate;
    private float fireCountdown = 0f;
    [SerializeField] private float moveSpeed;
    private bool gotPoint;
    public bool isEndPath;
    public GameObject bulletPrephab;
    public Transform firePoint;
    private bool alreadyAttacked;
    private int pathIndex;

    public Animator animator;






    // Start is called before the first frame update
 
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (fireCountdown <= 0f)
        {
            alreadyAttacked = false;
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

        if (target != null)
        {
            if (Vector3.Distance(target.position, transform.position) <= attackRange+attackOffset)
            {
                AttackPlayer();
            }
            else
            {
                Follow();
            }
           
        }
        else
        {
            if (!isEndPath)
            {
                GoToPoint();
            }

           
        }
    }
    public void Follow()
    {
        animator.SetBool("isAttacking", false);
        animator.SetBool("isWalking", true);
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    public float turnSpeed = 10f;

    private void AttackPlayer()
    {
        animator.SetBool("isAttacking", true);
        //Make sure enemy doesn't move
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        if (!alreadyAttacked)
        {
            ///Attack code here
            Shoot();
            ///End of attack code

            alreadyAttacked = true;
        }
    }
    bool isAttacking;
    IEnumerator AnimationFixCorotine(float sec)
    {
        isAttacking = true;
        yield return new WaitForSeconds(sec);
        GameObject bullet = (GameObject)Instantiate(bulletPrephab, firePoint.position, firePoint.rotation);
        SimpleBullet simpleBullet = bulletPrephab.GetComponent<SimpleBullet>();
        simpleBullet.SetDamage(damage.GetValue());
        yield return new WaitForSeconds(sec);
        animator.SetBool("isAttacking", false);
        isAttacking = false;
    }
    public void Shoot()
    {
        if (!isAttacking)
        {

            StartCoroutine(AnimationFixCorotine(fireRate/2));
          
            /*  bulletScript bulletS = bullet.GetComponent<bulletScript>();
              if (bulletS != null)
              {
                  bulletS.damage = enemyDamage;
                  bulletS.Seek(target);
              } */
        }
    }

    private spawnerLogic spawnerScript;

    public void getSpawnerScript(spawnerLogic script)
    {
        spawnerScript = script;
    }
    public void getNextPoint(Transform nextPoint)
    {
        pointToGo = nextPoint;
        pathIndex++;
        gotPoint = true;

    }

    public void GoToPoint()
    {
        if (gotPoint)
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", true);
            Vector3 dir = pointToGo.position - transform.position;
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            if (Vector3.Distance(transform.position, pointToGo.position) <= 0.2f)
            {
                spawnerScript.nextPoint(pathIndex, this);
            }
            checkRay();
        }

    }

   

    public float rayDistanceCheck;

    public void checkRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistanceCheck))
        {
            if (hit.collider.tag == "Wall")
            {
                Debug.Log(hit.collider.gameObject.name);

                target = hit.transform;
                AttackPlayer();
            }
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= chaseRange)
        {
            target = nearestEnemy.transform;
            targetStats = nearestEnemy.GetComponent<CharacterStats>();
            attackOffset = targetStats.colliderOffset;
        }
        else
        {
            target = null;
        }
    }

    CharacterStats targetStats;
    float attackOffset;
    public override void Die()
    {
        WaveSpawner.instance.enemyAlive--;
        base.Die();
    }
}
