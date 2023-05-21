using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnDirector : MonoBehaviour
{


    public enum waveState
    {
        None = 0,
        North = 1,
        East = 2,
        West = 3,
        South = 4
    };

    public waveState currentWave;
    public float waveTimer;
    public float nextWaveTime;
    public int waveCount;
    public float waveMaxLength;
    public float waveMinLength;


    public float spawnRate;
    public float spawnTimer;
    public float nextSpawnTime;
    public float spawnMaxRate;
    public float spawnMinRate;
    public float spawnDifficulty;
    public GameObject nextEnemyToSpawn;


    public GameObject westSpawns;
    public GameObject southSpawns;
    public GameObject eastSpawns;
    public GameObject northSpawns;

    public GameObject enemyList;

    public GameObject AntHill;

    public GameObject baseEnemyPrefab;
    public GameObject zigzagEnemyPrefab;
    public GameObject fastEnemyPrefab;
    public GameObject enemySpawnPoint;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        waveTimer += Time.deltaTime;


        if (waveTimer >= nextWaveTime)
        {
            waveTimer = 0;
            if (currentWave == (waveState.None))
            {
                beginWave();
            }
            else
            {
                endWave();
            }
        }



        if (currentWave != (waveState.None))
        {
            spawnEnemies();
        }

    }

    public void spawnEnemies()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= nextSpawnTime)
        {
            


            chooseRandomSpawn(currentWave);

            spawnTimer = 0;
            nextSpawnTime = Random.Range(spawnMinRate / waveCount, spawnMaxRate / waveCount);

            spawnDifficulty = Random.Range(0, 50 + (waveCount * 2));


            if (spawnDifficulty >= 60)
            {
                nextEnemyToSpawn = Instantiate(fastEnemyPrefab);
            }
            else if (spawnDifficulty >= 40)
            {
                nextEnemyToSpawn = Instantiate(zigzagEnemyPrefab);
            }
            else 
            {
                nextEnemyToSpawn = Instantiate(baseEnemyPrefab);
            }

        }
        nextEnemyToSpawn.GetComponent<EnemyAI>().target = AntHill.transform;
        nextEnemyToSpawn.transform.SetParent(enemyList.transform);
        nextEnemyToSpawn.transform.position = enemySpawnPoint.transform.position;
    }




public void chooseRandomSpawn(waveState waveDirection)
{
    switch (waveDirection)
    {
        case waveState.South:
            enemySpawnPoint = southSpawns.transform.GetChild(Random.Range(0, southSpawns.transform.childCount - 1)).gameObject;
            break;
        case waveState.North:
            enemySpawnPoint = northSpawns.transform.GetChild(Random.Range(0, northSpawns.transform.childCount - 1)).gameObject;
            break;
        case waveState.East:
            enemySpawnPoint = eastSpawns.transform.GetChild(Random.Range(0, eastSpawns.transform.childCount - 1)).gameObject;
            break;
        case waveState.West:
            enemySpawnPoint = westSpawns.transform.GetChild(Random.Range(0, westSpawns.transform.childCount - 1)).gameObject;
            break;
    }
}

public void beginWave()
{
    currentWave = (waveState)Random.Range(1, 4);
    waveCount += 1;
    nextWaveTime = Random.Range(10, waveMaxLength);

}

public void endWave()
{
    currentWave = waveState.None;
    nextWaveTime = Random.Range(waveMinLength, waveMaxLength);
}

}
