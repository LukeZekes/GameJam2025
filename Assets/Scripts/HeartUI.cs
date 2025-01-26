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
        Hp = FindAnyObjectByType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHp();
        Debug.Log(Hp.health);
        HeartsSeen();
    }
    void HeartsSeen()
    {
        if (hp >= 14 && hp <= 20)
        {
            Hearts[0].SetActive(false);
        }
        if (hp <= 15 && hp >= 11)
        {
            Hearts[1].SetActive(false);
        }
        if (hp <= 10 && hp >= 6)
        {
            Hearts[2].SetActive(false);
        }
        if (hp <= 5 && hp >= 1)
        {
            Hearts[3].SetActive(false);
        }
        if(hp <= 0)
        {
            Hearts[4].SetActive(false);
        }

    }
    void UpdateHp()
    {
        Hp = FindAnyObjectByType<PlayerHealth>();
        hp = Hp.health;
    }

}
