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
        HeartsSeen();
    }
    void HeartsSeen()
    {
        if (hp >= 16 && hp <= 20)
        {
            Hearts[0].SetActive(false);
        }
        if (hp >= 11 && hp <= 15)
        {
            Hearts[1].SetActive(false);
        }
        if (hp >= 6 && hp <= 10)
        {
            Hearts[2].SetActive(false);
        }
        if (hp >= 1 && hp <= 5)
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
        hp = Hp.health;
    }

}
