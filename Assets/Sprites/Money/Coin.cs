using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin : EnemyBase
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.gameManager.money += 1;
        Destroy(gameObject);
        GameObject.Find("MoneyAmount").GetComponent<TextMeshProUGUI>().text = "Money: " + GameManager.gameManager.money;
    }
}
