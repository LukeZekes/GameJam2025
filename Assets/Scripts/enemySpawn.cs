using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemySpawn : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject sharkPrefab;
    public GameObject eelPrefab;
    float respawntime;
    public GameObject spawn;
    private int num;
    bool dead = true;

    // Update is called once per frame
    void Update()
    {
        num = Random.Range(0, 2);
        whoToSpawn();
    }
    private void spawnFish()
    {
        fishPrefab.transform.position = spawn.transform.position;
        GameObject fish = Instantiate(fishPrefab) as GameObject;
        fish.SendMessage("AliveAgain",true);
        dead = false;
    }
    private void spawnEel() 
    {
        eelPrefab.transform.position = spawn.transform.position;
        GameObject eel = Instantiate(eelPrefab) as GameObject;
        eel.SendMessage("AliveAgain", true);
        dead = false;
    }
    private void spawnShark()
    {
        sharkPrefab.transform.position = spawn.transform.position;
        GameObject shark = Instantiate(sharkPrefab) as GameObject;
        shark.SendMessage("AliveAgain", true);
        dead = false;
    }
    void whoToSpawn()
    {
        switch (num)
        {
            case 0: 
                if(dead == true)
                {
                    spawnFish();
                }
                break;
            case 1:
                if (dead == true)
                {
                    spawnShark();
                }
                break;
            case 2:
                if (dead == true)
                {
                    spawnEel();
                }
                break;
        }
    }
    void stillAlive(bool alive)
    {
        if(alive == true)
        {
            Debug.Log("dead");
            dead = false;
        }
        else 
        {
            Debug.Log("alive");
            dead = true;
        }
    }
}
