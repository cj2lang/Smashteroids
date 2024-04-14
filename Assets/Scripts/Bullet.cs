using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("Triggered: " + other.gameObject.name);
        if(other.gameObject.tag == "Player1")
        {
            FindObjectOfType<GameManagement>().HurtP1();
        }

        if(other.gameObject.tag == "Player2")
        {
            FindObjectOfType<GameManagement>().HurtP2();
        }
        // Check if the object it collided with is a wall
        if (other.gameObject.tag == "Wall")
        {
            // Destroy the bullet
            Destroy(gameObject);
        }
    }

    
}
