using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public static EnemyCreator enemyCreator;
    public float rightOffset;
    public GameObject enemy;
    public GameObject enemyStatic;
    public GameObject coin;
    public float moveDelta;
    public float coinInterval;
    private void Awake()
    {
        if (enemyCreator == null)
        {
            enemyCreator = this;
        }
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 0)) + Vector3.right * rightOffset;
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 3);
        InvokeRepeating("SpawnStaticEnemy", 7, 7);
        InvokeRepeating("SpawnCoins", 10, 10);
    }

    public void MoveWithPlayer()
    {
        transform.position = transform.position += Vector3.right * Player.player.speed;
    }

    public void SpawnStaticEnemy()
    {
        GameObject newEnemy = GameObject.Instantiate(enemyStatic);
        Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        camPos.z = 0;
        camPos.y += newEnemy.GetComponent<Collider2D>().bounds.size.y/2;
        newEnemy.transform.position = camPos + Vector3.right * 5;
    }

    public void SpawnEnemy()
    {
        GameObject newEnemy = GameObject.Instantiate(enemy);
        Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Random.value * Screen.height, 0));
        camPos.z = 0;
        newEnemy.transform.position = camPos + Vector3.right * 5;
    }

    public void SpawnCoins()
    {
        int amount = Random.Range(3, 10);
        Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Random.value * Screen.height, 0));
        camPos.z = 0;
        for (int i = 0; i < amount; i++)
        {
            GameObject newCoin = GameObject.Instantiate(coin);
            newCoin.transform.position = camPos + Vector3.right * i * coinInterval;
        }
    }
}
