//Vedasri Malatker

using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Game Objects
    GameObject player;

    //Components
    Rigidbody2D rbPlayer;
    Collider2D weapon;

    //Input
    InputAction Attack;

    //Private Variables
    private int health = 30;

    //Public Variables
    public int frame = 5;
    public bool isHeld;
    public float chargeTimer = 0;
    public float chargeMax = 4;
    public float baseTimer = 0;
    public float baseMax = 1;
    public int counter = 0;

    void Start()
    {
        Attack = InputSystem.actions.FindAction("Attack");

        rbPlayer = gameObject.GetComponent<Rigidbody2D>();
        weapon = gameObject.GetComponentInChildren<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        baseTimer -= Time.deltaTime;

        //Regular Attack
        if (Attack.IsPressed())
        {
            if(isHeld)
            {
                chargeTimer += Time.deltaTime;      //Checks Held Time for Attack
            }
        }

        //Charge Attack
        if(Attack.WasPressedThisFrame())
        {
            isHeld = true;      //Checks if Player is Holding Attack
            chargeTimer = 0;        //Current Charge Time

            if (counter == 0)       //Counter for Sequence Attack
            {
                baseTimer = baseMax;        
                counter++;

                //Animator      //First Frame of Attack
                DamageGiven("Regular1");
                Debug.Log("First Attack");
            }

            else if (counter == 1)
            {       
                
                if (baseTimer > 0)
                {
                    //Animator      //Second Frame of Attack
                    baseTimer = baseMax;
                    counter++;
                    Debug.Log("Second Attack");
                }

                else 
                {
                    //Animator      //First Frame of Attack

                    baseTimer = baseMax;
                    counter++;
                    Debug.Log("First Attack");

                }
            }

            else if (counter == 2)
            {
                if (baseTimer > 0)
                {
                    //3nd attack
                    counter = 0;
                    Debug.Log("Third Attack");
                }

                else
                {
                    //Animator      //First Frame of Attack

                    baseTimer = baseMax;
                    counter++;
                    Debug.Log("First Attack");

                }
            }
        }

        if (Attack.WasReleasedThisFrame())
        {
            isHeld = false;
            
            if (chargeTimer >= chargeMax)
            {
                //Animator      //Charge Attack
                chargeTimer = 0;
                DamageGiven("Charge");
                Debug.Log("Charge Attack");
            }
        }

    }

    int DamageGiven(string type)
    {
        int damage = 0;

        switch (type)
        {
            case "Regular1":
                damage = 5;
                break;

            case "Regular2":
                damage = 7;
                break;

            case "Regular3":
                damage = 10;
                break;

            case "Charge":
                damage = 20;
                break;
        }

        return damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(Attack.inProgress)
        {
            collision.gameObject.SendMessage("Hit", DamageGiven("Regular"));
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
