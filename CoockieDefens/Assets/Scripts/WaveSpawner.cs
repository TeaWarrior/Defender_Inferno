using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance;
    public event EventHandler OnWaveFinish;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More Than One Spwaneres");
          
            return;
        }
        instance = this;
    }

    public List<spawnerLogic> spawners = new List<spawnerLogic>();

    public int totalWaves;
    public int currentWave { private set; get; }

    public int totalEnemyInWave;
    private int enemyToSpawn;

    public int enemyAlive;

    public float waveCountDown;
    private float currentWaveCD;

    public float enemySpawnCountdown;
    private float currentEnemySpawnCountDown;

    public List<GameObject> enemyList = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        currentWave = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentWave > totalWaves)
        {
            WinCondition();
        }
        else
        {
            WaveCountDown();
        }
    }

   public void WaveCountDown()
    {
        if(enemyAlive<=0 && enemyToSpawn <= 0)
        {
            currentWaveCD -= Time.deltaTime;
            if (currentWaveCD <= 0f)
            {
                ResetWave();
                OnWaveFinish?.Invoke(this, EventArgs.Empty);
            }
        }
        if (enemyToSpawn > 0)
        {
            if (currentEnemySpawnCountDown <= 0f)
            {
                SpawnEnemy();
                currentEnemySpawnCountDown = enemySpawnCountdown;
            }
            currentEnemySpawnCountDown -= Time.deltaTime;
        }
       
        
    }
    public void ResetWave()
    {
        enemyToSpawn = totalEnemyInWave;
        currentWaveCD = waveCountDown;
        currentWave++;
    }

    GameObject randomEnemyPrephab;
   public void SpawnEnemy()
    {
        int spawnerNum = Random.Range(0, spawners.Count);
        RandomEnemySpawn();
        spawners[spawnerNum].spawnEnemy(randomEnemyPrephab);
        enemyToSpawn--;
        enemyAlive++;
    }

    public void RandomEnemySpawn()
    {
        int enemyListIndex = Random.Range(0, enemyList.Count);
        Debug.Log(enemyList.Count);
        randomEnemyPrephab = enemyList[enemyListIndex];
    }

    public bool isWin;
    public void WinCondition()
    {
        if (!isWin)
        {
            Debug.Log("Won");
            isWin = true;
        }
       
    }
}