using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    private int hp;
    private int attackPower;
    public enemySpawn spawner;
    public List<GameObject> Audios;
    private SpriteRenderer spriteRenderer;
    private int num;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WhichEnemy();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        num = Random.Range(0, 2);
    }
    // collison with the player and damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("TakeDamage", attackPower);
        }
    }
    // when the enemy takes damage
    void Hit(int damage)
    {
        hp -= damage;
        StartCoroutine(TurnRed());
        if (hp <= 0)
        {
            spawner.RemoveSpawn();
            ChooseAudio();
            Destroy(gameObject);
        }
    }

    IEnumerator TurnRed()
        {;
            spriteRenderer.color = new Color(1, 0.4f, 0.4f);
            yield return new WaitForSeconds(0.5f);
            spriteRenderer.color = Color.white;
        }
    
    // sees which enemy current hp and attack is
    void WhichEnemy()
    {
        if (gameObject.tag == "Fish")
        {
            hp = 5;
            attackPower = 5;
        }
        else if (gameObject.tag == "Shark")
        {
            hp = 10;
            attackPower = 5;
        }
        else if(gameObject.tag == "Eel")
        {
            hp = 7;
            attackPower = 10;
        }
    }
    void ChooseAudio()
    {
        switch (num)
        {
            case 0:
                SpawnAudio1();
                break;
            case 1:
                SpawnAudio2();
                break;
            case 2:
                SpawnAudio3();
                break;

        }
    }
    public void SpawnAudio1()
    {
        GameObject audio1 = Instantiate(Audios[0], gameObject.transform.position, Quaternion.identity);
        audio1.GetComponent<AudioSource>().Play();
        Destroy(audio1, 5f);
    }
    public void SpawnAudio2()
    {
        GameObject audio2 = Instantiate(Audios[1], gameObject.transform.position, Quaternion.identity);
        audio2.GetComponent<AudioSource>().Play();
        Destroy(audio2, 5f);
    }
    public void SpawnAudio3()
    {
        GameObject audio3 = Instantiate(Audios[2], gameObject.transform.position, Quaternion.identity);
        audio3.GetComponent<AudioSource>().Play();
        Destroy(audio3, 5f);
    }
}
