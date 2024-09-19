using System.Collections;
using UnityEngine;
public class PlayerShoot : MonoBehaviour
{
    GameObject player;
    public GameObject bullet;
    public float bulletSpeed = 12;
    float cooldown = 0.5f;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cooldown -= Time.deltaTime;
    }

    private void Update()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && cooldown <= 0)
        {
            cooldown = 0.5f;
            GetFirePoint();
        }

    }
    void GetFirePoint()
    {
        var firePoint = player.GetComponentInChildren<Transform>().position;

        var newBullet = Instantiate(bullet, firePoint, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0,bulletSpeed,0);
        AudioManager.Instance.Shoot();
    }



}
