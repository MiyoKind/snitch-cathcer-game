using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public static Border lowerBorder;
    public static Border upperBorder;
    Collider2D col;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
        if (this.gameObject.name == "LowerBorder")
        {
            lowerBorder = this;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)) + Vector3.down * col.bounds.size.y / 2;
        }
        else if (this.gameObject.name == "UpperBorder")
        {
            upperBorder = this;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)) - Vector3.down * col.bounds.size.y / 2;
        }
    }

    public void MoveWithPlayer()
    {
        transform.position += Vector3.right * Player.player.speed;
    }
}
