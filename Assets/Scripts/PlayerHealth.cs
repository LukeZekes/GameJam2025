//Vedasri Malatker

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    //Game Objects
    GameObject player;

    //Private Variables
    private int health = 25;

    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //Game Over
        }
    }

    void TakeDamage(int dmg)
    {
        if (health <= 0)
        {
            //Game Over
        }
        
        health = (health - dmg);
    }
}
