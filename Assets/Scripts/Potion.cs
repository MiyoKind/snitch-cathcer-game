using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : EnemyBase
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Обработка эффекта зелья
        }
    }
}
