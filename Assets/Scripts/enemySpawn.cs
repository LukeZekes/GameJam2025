using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public class enemySpawn : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject sharkPrefab;
    public GameObject eelPrefab;
    private int num;
    float timerFish, timerShark, timerEel;
    [SerializeField] float fishSpawnTime, sharkSpawnTime, eelSpawnTime;
    [SerializeField] int maxSpawns;
    int numSpawns;
    // Update is called once per frame

    void Start()
    {
        numSpawns = 0;
    }
    void Update()
    {
        timerFish += Time.deltaTime;
        timerShark += Time.deltaTime;
        timerEel += Time.deltaTime;
        num = Random.Range(0, 2);
        if (numSpawns < maxSpawns) whoToSpawn();
    }
    private void spawnFish()
    {
        numSpawns++;
        enemyAttack fish = Instantiate(fishPrefab, transform.position, Quaternion.identity).GetComponent<enemyAttack>();
        fish.spawner = this;
    }
    private void spawnEel() 
    {
        numSpawns++;
        enemyAttack eel = Instantiate(eelPrefab, transform.position, Quaternion.identity).GetComponent<enemyAttack>();
        eel.spawner = this;
    }
    private void spawnShark()
    {
        numSpawns++;
        enemyAttack shark = Instantiate(sharkPrefab, transform.position, Quaternion.identity).GetComponent<enemyAttack>();
        shark.spawner = this;
    }
    void whoToSpawn()
    {
        switch (num)
        {
            case 0:
                if(timerFish >= fishSpawnTime)
                {
                    spawnFish();
                    timerFish = 0;
                }
                break;
            case 1:
                if (timerShark >= sharkSpawnTime)
                {
                    spawnShark();
                    timerShark = 0;
                }
                break;
            case 2:
                if (timerEel >= eelSpawnTime)
                {
                    spawnEel();
                    timerEel = 0;
                }
                break;
        }
    }
    public void RemoveSpawn() {
        numSpawns = Mathf.Max(0, numSpawns - 1); // This shouldn't ever go  below 0 but just to be safe
    }
}
