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
        rb.velocity = new Vector2(Player.player.rb.velocity.x * -0.1f ,0);
    }
}
