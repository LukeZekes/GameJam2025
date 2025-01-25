//Vedasri Malatker

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    //Game Objects
    GameObject player;

    //Private Variables
    private int health = 10;

    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //Game Over
            Debug.Log("dead");
        }
    }

    void TakeDamage(int dmg)
    {
        if (health <= 0)
        {
            //Game Over
            Debug.Log("dead");
        }
        
        health = (health - dmg);
        Debug.Log("hit!");
    }
}
