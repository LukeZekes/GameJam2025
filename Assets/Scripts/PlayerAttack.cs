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

    [SerializeField]
    int AttDMG1 = 5, AttDMG2 = 8, AttDMG3 = 10;

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
                    weapon.GetComponent<WeaponCheck>().DamageGiven(AttDMG1);
                    PerformAttack(1);
                    chainCount++;
                    chainTimer = 1;
                    break;
                case 1:
                    weapon.GetComponent<WeaponCheck>().DamageGiven(AttDMG2);
                    PerformAttack(2);
                    chainCount++;
                    chainTimer = 1;
                    break;
                case 2:
                    weapon.GetComponent<WeaponCheck>().DamageGiven(AttDMG3);
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
                SpawnBubbles(3);
                break;
            case 2:
                attackTimer = attack2Time;
                weapon.SetActive(true);
                SpawnBubbles(6);
                break;
            case 3:
                attackTimer = attack3Time;
                weapon.SetActive(true);
                SpawnBubbles(9);
                break;
        }
    }

    void SpawnBubbles(int count)
    {
        int i = 0;
        //while (i < count)
        //{
            Vector3 point = new Vector3(Random.Range(-1,1), Random.Range(-1,1), 0);
            //if (weapon.GetComponent<>)
        //}
    }
}
