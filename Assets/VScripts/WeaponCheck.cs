//Vedasri Malatker

using UnityEngine;

public class WeaponCheck : MonoBehaviour
{
    int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { }

    // Update is called once per frame
    void Update()
    { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish") || collision.gameObject.CompareTag("Shark") || collision.gameObject.CompareTag("Eel"))
        {
            gameObject.SendMessage("Hit", damage);
            Debug.Log("Hit");
        }
    }

    public void DamageGiven(int ammount)
    {
        damage = ammount;
    }
}
