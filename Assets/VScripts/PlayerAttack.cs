//Vedasri Malatker

using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Rigidbody weapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "fish") || (collision.tag == "shark") || (collision.tag == "eel"))
        {
            collision.SendMessage("Take Damage", 5);
        }
    }
}
