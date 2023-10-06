using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public bool isBought;
    public Image skinImg;
    public TextMeshProUGUI balance;
    public GameManager gameManager;
    public Player player;
    public Transform fog;
    public GameObject buyButton;
    public GameObject price;
    public int cost;
    public int skinNum;

    private void Awake()
    {
        var allKids = GetComponentsInChildren<Transform>();
        fog = allKids.Where(k => k.gameObject.name == "fog").FirstOrDefault();
        skinImg = allKids.Where(k => k.gameObject.name == "SkinIcon").FirstOrDefault().GetComponent<Image>();
        price = allKids.Where(k => k.gameObject.name == "Price").FirstOrDefault().gameObject;
        allKids.Where(k => k.gameObject.name == "ValueText").FirstOrDefault().GetComponent<TextMeshProUGUI>().text = cost.ToString();
    }

    void OnEnable()
    {
        balance.text = gameManager.money.ToString();
    }

    public void Buy()
    {
        if (isBought)
        {
            player.ChangeSkin(skinNum);
            return;
        }
        if (gameManager.money >= cost)
        {
            gameManager.money -= cost;
            player.ChangeSkin(skinNum);
            Destroy(fog.gameObject);
            Destroy(price);
            skinImg.color = new Color(1, 1, 1);
            balance.text = gameManager.money.ToString();
            isBought = true;
            return;
        }
    }

    void Start()
    {
        if (isBought)
        {
            Destroy(fog.gameObject);
            Destroy(price);
            skinImg.color = new Color(1, 1, 1);
        }
    }
}
