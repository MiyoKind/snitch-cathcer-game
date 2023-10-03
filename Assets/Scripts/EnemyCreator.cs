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
    public GameObject[] figures;
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
        InvokeRepeating("SpawnFigureCoins", 2, 7);
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

    //public void SpawnCoins()
    //{
    //    int amount = Random.Range(3, 10);
    //    Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Random.value * Screen.height, 0));
    //    camPos.z = 0;
    //    for (int i = 0; i < amount; i++)
    //    {
    //        GameObject newCoin = GameObject.Instantiate(coin);
    //        newCoin.transform.position = camPos + Vector3.right * i * coinInterval;
    //    }
    //}

    public void SpawnFigureCoins()
    {
        float c = Random.value;// Random.Range(0f, 1f);
        Debug.Log(c);
        if (c > 0.8f)
        {
            float h = Random.Range(0.6f, 0.75f);
            Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, h * Screen.height, 0));
            camPos.z = 0;
            if (figures.Length > 0)
            {
                int randomIndex = Random.Range(0, figures.Length);
                GameObject selectedFigure = figures[randomIndex];
                GameObject newFigureCoin = GameObject.Instantiate(selectedFigure);
                newFigureCoin.transform.position = camPos + Vector3.right * 5;
            }
        }
        else if ((0.8f >= c) && (c > 0.2f))
        {
            int amount = Random.Range(3, 10);
            Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Random.Range(0.1f, 0.9f) * Screen.height, 0));
            camPos.z = 0;
            for (int i = 0; i < amount; i++)
            {
                GameObject newCoin = GameObject.Instantiate(coin);
                newCoin.transform.position = camPos + Vector3.right * i * coinInterval;
            }
        }
        
        //GameObject newFigureCoin = GameObject.Instantiate(figure);
        //newFigureCoin.transform.position = camPos + Vector3.right * 5;
    }
}
