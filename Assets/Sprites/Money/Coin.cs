using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin : EnemyBase
{
    public AudioSource[] moneyPickAudio;
    public GameObject moneyPickAnimation;
    public TextMeshProUGUI moneyText;

    public int moneyAmount;

    public override void Start()
    {
        base.Start();
        moneyText = GameObject.Find("RunMoneyAmount").GetComponent<TextMeshProUGUI>();
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            GameManager.gameManager.runMoney += moneyAmount;
            Destroy(gameObject);
            Instantiate(moneyPickAnimation, transform.position, Quaternion.identity);
            int randomIndex = Random.Range(0, moneyPickAudio.Length);
            moneyPickAudio[randomIndex].Play();
            moneyText.text = "Галлеонов собрано: " + GameManager.gameManager.runMoney;
        }
    }
}
