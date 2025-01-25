//Vedasri Malatker

using UnityEngine;

public class WeaponCheck : MonoBehaviour
{
    Collider2D weapon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       weapon = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    { }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //if (firsthit)
        {
            gameObject.SendMessage("Hit", DamageGiven(1));
        }

        //if (secondhit)
        {
            gameObject.SendMessage("Hit", DamageGiven(2));
        }

        //if (thirdhit)
        {
            gameObject.SendMessage("Hit", DamageGiven(3));
        }

        //if (chargehit)
        {
            gameObject.SendMessage("Hit", DamageGiven(5));
        }
        

    }

    int DamageGiven(int type)
    {
        int damage = 0;

        switch (type)
        {
            case 1: //First Attack
                damage = 5;
                break;

            case 2: //Second Attack
                damage = 7;
                break;

            case 3: //Third Attack
                damage = 10;
                break;

            case 5: //Charge Attack
                damage = 20;
                break;
        }

        return damage;
    }
}
