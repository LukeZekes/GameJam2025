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
        Debug.Log(Hp.health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void HeartsSeen()
    {

    }
    void UpdateHp()
    {
        hp = Hp.health;
    }

}
