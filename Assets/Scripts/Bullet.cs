using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float collisionDelay = 0.2f;
    private Rigidbody2D rb;
    private Collider2D bulletCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletCollider = GetComponent<Collider2D>();
        rb.velocity = transform.up * speed;

        bulletCollider.enabled = false;
        StartCoroutine(EnableColliderAfterDelay());
    }

    IEnumerator EnableColliderAfterDelay()
    {
        yield return new WaitForSeconds(collisionDelay);
        bulletCollider.enabled = true;
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
