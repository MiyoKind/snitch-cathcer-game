using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    private void Start()
    {
        if (GameManager.gameManager.musicStatus)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
