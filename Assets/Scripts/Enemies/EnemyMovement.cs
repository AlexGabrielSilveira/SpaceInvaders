using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject projectilePrefab;
    float moveSpeed = 0.05f;
    float directionX = 1f;
    private List<GameObject> enemies = new List<GameObject>();
    public int cooldown = 2; 
    private float lastShootTime = 0f;

    public void AddToList(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    private void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * directionX * Time.deltaTime);
        EnemyShoot();
    }

    void EnemyShoot()
    {
        
        if (Time.time - lastShootTime >= cooldown)
        {
            if (enemies.Count > 0)
            {  
                int randomIndex = Random.Range(0, enemies.Count);
                GameObject randomEnemy = enemies[randomIndex];

              if (randomEnemy != null)
                {
                    Instantiate(projectilePrefab, randomEnemy.transform.position, Quaternion.identity);
                    lastShootTime = Time.time; 

                 
                }
            }
        }
    }

}
