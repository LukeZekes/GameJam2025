using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemySpawn : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject sharkPrefab;
    public GameObject eelPrefab;
    float respawntime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void spawnFish()
    {
        GameObject fish = Instantiate(fishPrefab) as GameObject;
    }
    private void spawnEel() 
    {
        GameObject eel = Instantiate(eelPrefab) as GameObject;
    }
    private void spawnShark()
    {
        GameObject shark = Instantiate(sharkPrefab) as GameObject;
    }
    void WhichEnemy()
    {
        if (gameObject.tag == "Fish")
        {
            respawntime = 1.0f;
        }
        else if (gameObject.tag == "Shark")
        {
            respawntime = 1.5f;
        }
        else if (gameObject.tag == "Eel")
        {
            respawntime = 2.0f;
        }
    }
    IEnumerator fishSwim()
    {
        while (true) 
        {
            yield return new WaitForSeconds(respawntime);
            spawnFish();
        }
    }
    IEnumerator eelSwim()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawntime);
            spawnEel();
        }
    }
    IEnumerator sharkSwim()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawntime);
            spawnShark();
        }
    }
}
