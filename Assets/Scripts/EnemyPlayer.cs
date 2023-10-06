using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EnemyPlayer : EnemyBase
{
    public float vertSpeed;
    public int skin;


    public Sprite[] playerSprites;
    public RuntimeAnimatorController[] playerControllers;

    void Awake()
    {
        skin = Random.Range(0, 4);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.5f * Player.player.speed, Random.value < 0.5f ? vertSpeed : -vertSpeed);
        ChangeSkin(skin);
    }

    public void ChangeSkin(int skin)
    {
        this.GetComponent<SpriteRenderer>().sprite = playerSprites[skin];
        this.GetComponent<Animator>().runtimeAnimatorController = playerControllers[skin];
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && skin != GameManager.gameManager.currentSkin)
        {
            Debug.Log("Hit!");
            GameManager.gameManager.EndGame();
            return;
        }
        if (collision.tag == "Border")
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
    }
}
