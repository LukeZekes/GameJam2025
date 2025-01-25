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

    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.tag == "Fish") || (collision.tag == "Shark") || (collision.tag == "Eel"))
        {
            gameObject.SendMessage("Hit", damage);
        }
    }

    public void DamageGiven(int amount)
    {
        damage = amount;
    }
}
