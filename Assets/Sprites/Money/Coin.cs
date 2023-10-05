using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin : EnemyBase
{
    //public AudioSource moneyPickAudio;
    public GameObject moneyPickAnimation;
    public override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Player")
        {
            GameManager.gameManager.runMoney += 1;
            Destroy(gameObject);
            Instantiate(moneyPickAnimation, transform.position, Quaternion.identity);
            //moneyPickAudio.Play();
            GameObject.Find("RunMoneyAmount").GetComponent<TextMeshProUGUI>().text = "Галлеонов собрано: " + GameManager.gameManager.runMoney;
        }
    }
}
