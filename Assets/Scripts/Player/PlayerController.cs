using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject player;
    public float playerSpeed = 300; 
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        player.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal * (playerSpeed * Time.fixedDeltaTime), 0);
    }
    
}
