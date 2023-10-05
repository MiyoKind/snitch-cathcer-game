using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public float enemyChance;
    public float enemyBladjChance;
    public float enemyRingChance;
    public float coinChance;
    public float snitchChance;
    public float spawnRate;
    public float vergaChance;
    public float FlappyBirdChance;
    public static EnemyCreator enemyCreator;
    public float rightOffset;
    public GameObject enemy;
    public GameObject enemyBladj;
    public GameObject enemyRing;
    public GameObject coin;
    public GameObject snitch;
    public GameObject vergaspell;
    public GameObject flappyBird;
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
        InvokeRepeating("Spawn", 3, spawnRate);
        //InvokeRepeating("SpawnEnemy", 0, 3);
        //InvokeRepeating("SpawnBladj", 7, 7);
        //InvokeRepeating("SpawnFigureCoins", 2, 7);
        //InvokeRepeating("SpawnRings", 3, 4);
    }

    public void Spawn()
    {
        float seed = Random.value;
        if (seed <= snitchChance)
        {
            SpawnSnitch();
            return;
        }
        if (seed <= vergaChance)
        {
            SpawnVergaSpell();
            return;
        }
        if (seed < FlappyBirdChance)
        {

            return;
        }
        seed = Random.value;
        if (seed <= coinChance)
        {
            SpawnFigureCoins();
            return;
        }
        seed = Random.value;
        if (seed <= enemyChance)
        {
            SpawnEnemy();
            return;
        }
        seed = Random.value;
        if (seed <= enemyRingChance)
        {
            SpawnRings();
            return;
        }
        seed = Random.value;
        if (seed <= enemyBladjChance)
        {
            SpawnBladj();
            return;
        }
    }

    public void MoveWithPlayer()
    {
        //transform.position = transform.position += Vector3.right * Player.player.speed;
        transform.position = new Vector3(Player.player.transform.position.x, transform.position.y, transform.position.z);
    }

    public void SpawnBladj()
    {
        GameObject newEnemy = GameObject.Instantiate(enemyBladj);
        Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height * (Random.value * 0.45f + 0.5f), 0));
        camPos.z = 0;
        newEnemy.transform.position = camPos + Vector3.right * rightOffset;
    }

    public void SpawnRings()
    {
        GameObject newEnemy = GameObject.Instantiate(enemyRing);
        //float h = Random.Range(0f, 0.1f);
        Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, -Screen.height, 0));
        camPos.z = 0;
        camPos.y += newEnemy.GetComponent<Collider2D>().bounds.size.y * (Random.value * 0.2f + 0.4f);
        newEnemy.transform.position = camPos + Vector3.right * rightOffset;
    }

    public void SpawnEnemy()
    {
        GameObject newEnemy = GameObject.Instantiate(enemy);
        Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, (Random.value * 0.9f + 0.05f) * Screen.height, 0));
        camPos.z = 0;
        newEnemy.transform.position = camPos + Vector3.right * rightOffset;
    }

    public void SpawnFigureCoins()
    {
        float c = Random.value;// Random.Range(0f, 1f);
        Debug.Log(c);
        if (c > 0.6f)
        {
            float h = Random.Range(0.6f, 0.75f);
            Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, h * Screen.height, 0));
            camPos.z = 0;
            if (figures.Length > 0)
            {
                int randomIndex = Random.Range(0, figures.Length);
                GameObject selectedFigure = figures[randomIndex];
                GameObject newFigureCoin = GameObject.Instantiate(selectedFigure);
                newFigureCoin.transform.position = camPos + Vector3.right * rightOffset;
            }
        }
        else if ((0.6f >= c) && (c > 0.2f))
        {
            int amount = Random.Range(3, 10);
            Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Random.Range(0.1f, 0.9f) * Screen.height, 0));
            camPos.z = 0;
            for (int i = 0; i < amount; i++)
            {
                GameObject newCoin = GameObject.Instantiate(coin);
                newCoin.transform.position = camPos + Vector3.right * rightOffset + Vector3.right * i * coinInterval;
            }
        }
    }

    public void SpawnSnitch()
    {
        GameObject newEnemy = GameObject.Instantiate(snitch);
        Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, (Random.value * 0.9f + 0.05f) * Screen.height, 0));
        camPos.z = 0;
        newEnemy.transform.position = camPos + Vector3.right * rightOffset;
    }

    public void SpawnVergaSpell()
    {
        GameObject newEnemy = GameObject.Instantiate(vergaspell);
        Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, (Random.value * 0.9f + 0.05f) * Screen.height, 0));
        camPos.z = 0;
        newEnemy.transform.position = camPos + Vector3.right * rightOffset;

    }
    public void SpawnFlappyBirdSpell()
    {
        GameObject newEnemy = GameObject.Instantiate(flappyBird);
        Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, (Random.value * 0.9f + 0.05f) * Screen.height, 0));
        camPos.z = 0;
        newEnemy.transform.position = camPos + Vector3.right * rightOffset;
    }
}
