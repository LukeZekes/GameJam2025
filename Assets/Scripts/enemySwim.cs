using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class enemySwim : MonoBehaviour
{
    private Rigidbody2D rb;
    private float X;
    private float speed;
    private Vector3 position;
    private bool facing;
    //on Start
    private void Start()
    {
        position = transform.position;
        rb = GetComponent<Rigidbody2D>();
        X = -1f;
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // when collieds with wall
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Fish") || collision.gameObject.CompareTag("Shark") || collision.gameObject.CompareTag("Eel"))
        {
            X *= -1f;
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2 (X * speed, rb.linearVelocity.y);
    }
    private void LateUpdate()
    {
       
    }
    void whichWay()
    {
        if(X > 0)
        {
            facing = true;
        }
        else if(X < 0)
        {
            facing= false;
        }
        if((facing && position.x < 0)||(!facing && position.x > 0))
        {
            position.x  *= -1;
        }
        transform.position = position;
    }
}
