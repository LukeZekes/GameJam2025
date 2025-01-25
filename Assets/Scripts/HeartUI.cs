using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HeartUI : MonoBehaviour
{
    public List<GameObject> Hearts;
    public static int hp = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void GetHP(int current)
    {
        hp = current;
    }

}
