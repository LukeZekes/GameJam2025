using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    GameObject weapon;
    InputAction attack;

    [SerializeField] //for peaking only
    float chainTimer;
    [SerializeField] //for peaking only
    int chainCount;

    [SerializeField]
    float attack1Time = 0.05f, attack2Time = 0.08f, attack3Time = 0.11f;
    float attackTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        weapon = GameObject.Find("Weapon");
        weapon.SetActive(false);
    }
    void Start()
    {
        chainTimer = 0;
        chainCount = 0;
        attackTimer = 0;
        attack = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        if (chainTimer <= 0)
        {
            chainCount = 0;
        }
        else {chainTimer -= Time.deltaTime;}


        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else {weapon.SetActive(false);}


        if (attack.WasPerformedThisFrame() && attackTimer <= 0)
        {
            switch (chainCount)
            {
                case 0: // first attack
                    //weapon.script.damage(value)
                    PerformAttack(1);
                    chainCount++;
                    chainTimer = 1;
                    break;
                case 1:
                    //weapon.script.damage(value)
                    PerformAttack(2);
                    chainCount++;
                    chainTimer = 1;
                    break;
                case 2:
                    chainCount = 0;
                    chainTimer = 0;
                    PerformAttack(3);
                    break;
            }
        }
    }

    void PerformAttack(int Chain)
    {
        //TODO: add more precise function for managing the hitbox when animations are in
        switch(Chain)
        {
            case 1:
                attackTimer = attack1Time;
                weapon.SetActive(true);
                break;
            case 2:
                attackTimer = attack2Time;
                weapon.SetActive(true);
                break;
            case 3:
                attackTimer = attack3Time;
                weapon.SetActive(true);
                break;
        }
    }
}
