using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Sprite unmuted;
    public Sprite muted;
    Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    private void OnEnable()
    {
        IconCheck();
    }

    public void IconCheck()
    {
        if (GameManager.gameManager.musicStatus)
        {
            img.sprite = unmuted;
        }
        else
        {
            img.sprite = muted;
        }
    }
}
