using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float jumpSpeed;
    public float maxSpeed;
    public float accel;

    public Sprite[] playerSprites;
    public AnimatorController[] playerControllers;

    public Rigidbody2D rb;

    public static Player player;

    void Awake()
    {
        if (player == null)
        {
            player = this;
        }
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartMoving()
    {
        rb.velocity = Vector2.right * speed;
    }

    public void StopMoving()
    {
        rb.velocity = new Vector2(0,rb.velocity.y);
    }

    public void MoveForward()
    {
        transform.position += Vector3.right * speed;
    }

    public void Jump()
    {
        if (rb.velocity.y < maxSpeed)
        {
            rb.velocity += Vector2.up * accel;
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, maxSpeed);
        }
    }

    public void ChangeSkin(int skin)
    {
        GameManager.gameManager.currentSkin = skin;
        this.GetComponent<SpriteRenderer>().sprite = playerSprites[skin];
        this.GetComponent<Animator>().runtimeAnimatorController = playerControllers[skin];
        SaveSystem.ss.SaveGame();
    }
}
