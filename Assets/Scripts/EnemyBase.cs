using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected Player player;
    protected Rigidbody2D rb;

    // Start is called before the first frame update
    public virtual void Start()
    {
        player = Player.player;
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("CheckToDestroy", 7, 2);
    }

    // Update is called once per frame
    //public virtual void Update()
    //{
    //    if (transform.position.x + 10 < player.transform.position.x)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    public virtual void CheckToDestroy()
    {
        if (transform.position.x + 10 < player.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Hit!");
            GameManager.gameManager.EndGame();
            return;
        }
    }
}
