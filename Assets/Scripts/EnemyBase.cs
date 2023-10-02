using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected Player player;
    protected Rigidbody2D rb;
    public float test;

    // Start is called before the first frame update
    public virtual void Start()
    {
        player = Player.player;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (transform.position.x + 10 < player.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("Hit!");
            return;
        }
    }
}
