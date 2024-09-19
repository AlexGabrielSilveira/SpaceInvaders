using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -5.4f)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameManager.Instance.GameOver();
            AudioManager.Instance.DeathExplosion();
        }
        if(collision.gameObject.CompareTag("protect"))
        {
            Destroy(gameObject);
            AudioManager.Instance.DeathExplosion();
        }
    }
}
