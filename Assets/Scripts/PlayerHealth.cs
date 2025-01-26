//Vedasri Malatker

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Game Objects
    GameObject player;
    //Private Variables
    public int health = 25;

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int dmg)
    {        
        health -= dmg;

        if (health <= 0)
        {
            //Game Over
            GameManager.Instance.LoseGame();
        }
    }
}
