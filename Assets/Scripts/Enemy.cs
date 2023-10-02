using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : EnemyBase
{
    float maxHeight;
    float minHeight;
    public float speed;

    public override void Start()
    {
        base.Start();
        maxHeight = transform.position.y + EnemyCreator.enemyCreator.moveDelta / 2;
        minHeight = transform.position.y - EnemyCreator.enemyCreator.moveDelta / 2;
        if (Random.value < 0.5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.name == "LowerBorder")
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            return;
        }
        if (collision.name == "UpperBorder")
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            return;
        }
        if (collision.name == "Player")
        {
            //Код обработки отнимания хп
        }
    }

    public override void Update()
    {
        base.Update();
        VelocityChange();
    }

    public void VelocityChange()
    {
        if (transform.position.y > maxHeight)
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
        }
        if (transform.position.y < minHeight)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
    }
}
