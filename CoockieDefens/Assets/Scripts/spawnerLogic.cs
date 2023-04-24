using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerLogic : MonoBehaviour
{

    [SerializeField] Transform spawnPoint, movePoint;
    [SerializeField] Transform[] pathPoints;
 
    // Start is called before the first frame update

    private void Awake()
    {
        pathPoints = new Transform[transform.childCount];
        for (int i = 0; i < pathPoints.Length; i++)
        {
          pathPoints[i]=  transform.GetChild(i);
        }
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
    
  
    public void spawnEnemy(GameObject enemyPrephab)
    {
        GameObject enemyBot = Instantiate(enemyPrephab, spawnPoint.position, Quaternion.identity);
        EnemyAI scriptEnemy = enemyBot.GetComponent<EnemyAI>();
        scriptEnemy.getNextPoint(pathPoints[1]);
        scriptEnemy.getSpawnerScript(this);

    }

    public void nextPoint(int pathIndex, EnemyAI script)
    {
        if (pathPoints.Length < pathIndex+1)
        {
            script.isEndPath = true;
            return;
        }
        script.getNextPoint(pathPoints[pathIndex]);
    }
}
