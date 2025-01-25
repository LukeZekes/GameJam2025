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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            collision.gameObject.SendMessage("TakeDamage", attackPower);
        }
    }
    void Hit(int damage)
    {
        if (damage <= 0)
        {
            Destroy(gameObject);
        }
        hp -= damage;
    }
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
