using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    SpawnManager spawnManager;

    private void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.Instance.AddScore(30);
            AudioManager.Instance.KillInvader();
            spawnManager.enemiesAlive--;
        }
        else if (collision.gameObject.CompareTag("Enemy1"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.Instance.AddScore(20);
            AudioManager.Instance.KillInvader();
            spawnManager.enemiesAlive--;
        }
        else if (collision.gameObject.CompareTag("Enemy2"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.Instance.AddScore(10);
            AudioManager.Instance.KillInvader();
            spawnManager.enemiesAlive--;
        }
    }
}
