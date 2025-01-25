using Unity.VisualScripting;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    int hp;
    int attackPower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WhichEnemy();
    }
    // collison with the player and damage
    private void OnCollision2DEnter(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SendMessage("TakeDamage", attackPower);
        }
    }
    // when the enemy takes damage
    void Hit(int damage)
    {
        if (damage <= 0)
        {
            Destroy(gameObject);
            SendMessage("stillAlive",false);
        }
        hp -= damage;
        SendMessage("stillAlive", true);
    }
    // sees which enemy current hp and attack is
    void WhichEnemy()
    {
        if (gameObject.tag == "Fish")
        {
            hp = 5;
            attackPower = 3;
            Debug.Log("Fish");
        }
        else if (gameObject.tag == "Shark")
        {
            hp = 10;
            attackPower = 5;
            Debug.Log("Shark");
        }
        else if(gameObject.tag == "Eel")
        {
            hp = 7;
            attackPower = 10;
            Debug.Log("Eel");
        }
    }
}
