using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ParallaxController parallaxController;
    public static GameManager gameManager;
    public GameObject startMenu;
    public GameObject gameplayMenu;
    Player player;
    EnemyCreator enemyCreator;
    Border lowerBorder;
    Border upperBorder;
    public Hold but;
    public int money;
    public GameObject endMenu;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }
    private void Start()
    {
        player = Player.player;
        enemyCreator = EnemyCreator.enemyCreator;
        lowerBorder = Border.lowerBorder;
        upperBorder = Border.upperBorder;
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Debug.Log("Hui");
        Time.timeScale = 1;
        //player.StartMoving();
        startMenu.SetActive(false);
        gameplayMenu.SetActive(true);
    }

    public void EndGame()
    {
        endMenu.SetActive(true); 
        parallaxController.parallaxSpeed = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void FixedUpdate()
    {
        //foreach (Touch touch in Input.touches)
        //{
        //    player.Jump();
        //}
        player.MoveForward();
        CameraManager.camera.MoveCameraWithPlayer();
        enemyCreator.MoveWithPlayer();
        lowerBorder.MoveWithPlayer();
        upperBorder.MoveWithPlayer();
        if (but.buttonPressed)
        {
            player.Jump();
        }
    }
}
