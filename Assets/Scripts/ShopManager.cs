using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI balance;
    public GameManager gameManager;
    public Player player;
    public GameObject fog;
    public GameObject buyButton;
    public int cost;
    public int skinNum;
    // Start is called before the first frame update
    void OnEnable()
    {
        balance.text = gameManager.money.ToString();
    }

    public void Buy()
    {
        if (gameManager.money >= cost)
        {
            gameManager.money -= cost;
            player.ChangeSkin(skinNum);
            Destroy(fog);
            balance.text = gameManager.money.ToString();
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
