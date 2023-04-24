using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai  : MonoBehaviour
{
    public float range = 15f;
    public Transform target;
    public string enemyTag = "Player";
    // Start is called before the first frame update
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
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    bool isCorotineStart;
    IEnumerator SearchTargetCorotine()
    {
        isCorotineStart = true;
        yield return new WaitForSeconds(0.5f);

        UpdateTarget();
        isCorotineStart = false;
    }
}
