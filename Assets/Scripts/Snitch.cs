using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snitch : Coin
{
    public float speed;

    public override void Start()
    {
        base.Start();
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
    }
}
