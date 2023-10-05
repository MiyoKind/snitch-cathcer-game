using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPick : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        InvokeRepeating("CheckToDestroy", 7, 2);
    }

    public void CheckToDestroy()
    {
        if (transform.position.x + 10 < Player.player.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }
}
