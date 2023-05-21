using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shellSpawner : MonoBehaviour
{
    [SerializeField] GameObject shellPrefab;
    [SerializeField] GameObject goldenShellPrefab;
    [SerializeField] Transform spawnZone;

    [SerializeField] int goldenChance = 25;
    [SerializeField] Vector2 spawnIntervalRange;
    [SerializeField] Vector2 spawnAmountRange;
    [SerializeField] float spawnZ = -5;

    float timer = 0;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            for (int i = 0;i < Random.Range(spawnAmountRange.x, spawnAmountRange.y);i++)
            {
                SpawnShell();
            }
            timer= Random.Range(spawnIntervalRange.x,spawnIntervalRange.y);
        }
    }

    void SpawnShell()
    {
        //Get random position in Zone Rectangle
        Vector3 spawnPoint = new Vector3(Random.Range(-spawnZone.localScale.x / 2, spawnZone.localScale.x / 2), Random.Range(-spawnZone.localScale.y / 2, spawnZone.localScale.y / 2), spawnZ);



        //If no obstacle hit will instantiate either shell or golden shell
        if (Random.Range(0,goldenChance) == 0)
        {
            //Spawn Golden Shell
            Instantiate(goldenShellPrefab, spawnPoint, Quaternion.identity);
        }
        else
        {
            //Spawn Normal Shell
            Instantiate(shellPrefab, spawnPoint, Quaternion.identity);
        }
        
    }

    public Vector2 RandomPointOnBox()
    {
        float spawnPosX = Random.Range(spawnZone.position.x - spawnZone.localScale.x / 2, spawnZone.position.x + spawnZone.localScale.x / 2);
        float spawnPosY = Random.Range(spawnZone.position.y - spawnZone.localScale.y / 2, spawnZone.position.y + spawnZone.localScale.y / 2);
        return new Vector2(spawnPosX, spawnPosY);
    }

}
