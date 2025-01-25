using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public class enemySpawn : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject sharkPrefab;
    public GameObject eelPrefab;
    float respawntime;
    public GameObject spawn;
    private int num;
    float timerF;
    float timerS;
    float timerE;
    // Update is called once per frame
    void Update()
    {
        timerF += Time.deltaTime;
        timerS += Time.deltaTime;
        timerE += Time.deltaTime;
        num = Random.Range(0, 2);
        whoToSpawn();
    }
    private void spawnFish()
    {
        fishPrefab.transform.position = spawn.transform.position;
        GameObject fish = Instantiate(fishPrefab) as GameObject;
    }
    private void spawnEel() 
    {
        eelPrefab.transform.position = spawn.transform.position;
        GameObject eel = Instantiate(eelPrefab) as GameObject;
    }
    private void spawnShark()
    {
        sharkPrefab.transform.position = spawn.transform.position;
        GameObject shark = Instantiate(sharkPrefab) as GameObject;
    }
    void whoToSpawn()
    {
        switch (num)
        {
            case 0:
                if(timerF >= 10)
                {
                    spawnFish();
                    timerF = 0;
                }
                break;
            case 1:
                if (timerS >= 13)
                {
                    spawnShark();
                    timerS = 0;
                }
                break;
            case 2:
                if (timerE >= 15)
                {
                    spawnEel();
                    timerE = 0;
                }
                break;
        }
    }
}
