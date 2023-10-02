using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public static Pause pause;
    // Start is called before the first frame update
    void Awake()
    {
        if (pause == null)
        {
            pause = this;
        }
    }

    public void Stop()
    {
        if (Time.timeScale >= 1) Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
}
