using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HeartUI : MonoBehaviour
{
    public PlayerHealth Hp;
    public List<GameObject> Hearts;
    public static int hp = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hp = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHp();
        HeartsSeen();
    }
    void HeartsSeen()
    {
        if (hp >= 14 && hp <= 20)
        {
            Hearts[0].active = false;
        }
        if (hp <= 15 && hp >= 11)
        {
            Hearts[1].active = false;
        }
        if (hp <= 10 && hp >= 6)
        {
            Hearts[2].active = false;
        }
        if (hp <= 5 && hp >= 1)
        {
            Hearts[3].active = false;
        }
        if(hp <= 0)
        {
            Hearts[4].active = false;
        }

    }
    void UpdateHp()
    {
        hp = Hp.health;
    }

}
