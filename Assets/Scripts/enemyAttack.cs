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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("TakeDamage", attackPower);
        }
    }
    // when the enemy takes damage
    void Hit(int damage)
    {
        if (damage <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
            SendMessage("stillAlive",false);
        }
        Debug.Log("Hit!");
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
        }
        else if (gameObject.tag == "Shark")
        {
            hp = 10;
            attackPower = 5;
        }
        else if(gameObject.tag == "Eel")
        {
            hp = 7;
            attackPower = 10;
        }
    }
}
