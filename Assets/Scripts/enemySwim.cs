using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class enemySwim : MonoBehaviour
{
    private Rigidbody2D rb;
    private float X;
    private float speed;
    private Vector3 position;
    private bool facing;
    private Animator anime;
    //on Start
    private void Start()
    {
        position = transform.position;
        rb = GetComponent<Rigidbody2D>();
        X = -1f;
        speed = 3f;
        anime = GetComponent<Animator>();
    }
    // when collieds with wall
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Fish") || collision.gameObject.CompareTag("Shark") || collision.gameObject.CompareTag("Eel"))
        {
            X *= -1f;
            if (facing == true)
            {
                facing = false;
                flip(facing);
            }
            else if (facing == false) 
            {
                facing = true;
                flip(facing);
            }
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2 (X * speed, rb.linearVelocity.y);
    }
    // flips sprite
    void flip(bool flip)
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = flip;
    }
}
