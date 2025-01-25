//Vedasri Malatker

using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour

{
    GameObject player;
    Rigidbody2D rbPlayer;

    private int health;

    void Start()
    {
        health = 30;
    }

    // Update is called once per frame
    void Update()
    {
        //button attack, triggers 

        //button smash

        //button charge
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
