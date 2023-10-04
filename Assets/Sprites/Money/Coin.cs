using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin : EnemyBase
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            GameManager.gameManager.runMoney += 1;
            Destroy(gameObject);
            GameObject.Find("RunMoneyAmount").GetComponent<TextMeshProUGUI>().text = "Галлеонов собрано: " + GameManager.gameManager.runMoney;
        }
    }
}
