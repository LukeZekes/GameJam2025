//Vedasri Malatker

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    //Game Objects
    GameObject player;

    //Private Variables
    private int health = 30;

    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            //Game Over
        }
    }

    void TakeDamage(int dmg)
    {
        if (health == 0)
        {
            //Game Over
        }
        
        health = (health - dmg);
    }
}
