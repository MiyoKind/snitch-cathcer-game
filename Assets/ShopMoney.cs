using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopMoney : MonoBehaviour
{
    TextMeshProUGUI tmp;
    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        this.tmp.text = GameManager.gameManager.money.ToString();
    }
}
