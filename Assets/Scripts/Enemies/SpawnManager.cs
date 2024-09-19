using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] spawnPoints;
    int rows = 16;
    EnemyMovement enemyMovement;
    public int enemiesAlive = 0; 
    bool canSpawn = false;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        SpawnEnemies(); 
    }

    private void Update()
    {
        if (enemiesAlive == 0)
        {
            canSpawn = true;
        }

        if (canSpawn)
        {
            if (enemiesAlive >= 80) 
            {
                canSpawn = false;
                return;
            }
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject spawnPoint = spawnPoints[i];
            GameObject enemyTospawn = null;

            switch (i)
            {
                case 0:
                    enemyTospawn = enemy[0];
                    break;
                case 1:
                case 2:
                    enemyTospawn = enemy[1];
                    break;
                case 3:
                case 4:
                    enemyTospawn = enemy[2];
                    break;
            }

            for (int row = 0; row < rows; row++)
            {
                if (enemyTospawn != null)
                {
                    Vector3 spawnPosition = spawnPoint.transform.position + new Vector3(row * 1f,0, 0);
                    GameObject newEnemy = Instantiate(enemyTospawn, spawnPosition, Quaternion.identity);
                    enemyMovement.AddToList(newEnemy);
                    enemiesAlive++; 

                    
                }
            }
        }
    }

}
