using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ParallaxController parallaxController;
    public static GameManager gameManager;
    public GameObject startMenu;
    public GameObject gameplayMenu;
    public float timeIterator;
    Player player;
    EnemyCreator enemyCreator;
    Border lowerBorder;
    Border upperBorder;
    public Hold but;
    public int money;
    public int runMoney;
    public int record;
    public int currentSkin;
    public GameObject endMenu;
    public bool dead = false;
    

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }
    private void Start()
    {
        SaveSystem.ss.LoadGame();
        player = Player.player;
        enemyCreator = EnemyCreator.enemyCreator;
        lowerBorder = Border.lowerBorder;
        upperBorder = Border.upperBorder;
        Time.timeScale = 0;
        player.ChangeSkin(currentSkin);
        GameObject.Find("StatMoney").GetComponent<TextMeshProUGUI>().text = "���� ��������: " + money;
        GameObject.Find("StatLenght").GetComponent<TextMeshProUGUI>().text = "��� ������: " + record + " �";
        timeIterator = Mathf.Exp(1);
        dead = false;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        player.StartMoving();
        startMenu.SetActive(false);
        gameplayMenu.SetActive(true);
        but.GameObject().SetActive(true);
        InvokeRepeating("Accelerate", 1, 2);

    }

    public void EndGame()
    {
        endMenu.SetActive(true);
        player.StopMoving();
        but.GameObject().SetActive(false);
        dead = true;
        but.buttonPressed = false;
        money += runMoney;
        if ((int)player.transform.position.x > record)
        {
            record = (int)player.transform.position.x;
        }
        SaveSystem.ss.SaveGame();
        //parallaxController.parallaxSpeed = 0;
        //Player.player.rb.velocity = Vector2.right * Player.player.speed;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void FixedUpdate()
    {
        CameraManager.camera.MoveCameraWithPlayer();
        enemyCreator.MoveWithPlayer();
        lowerBorder.MoveWithPlayer();
        upperBorder.MoveWithPlayer();
        if (but.buttonPressed)
        {
            player.Jump();
        }
    }

    public void Accelerate() //��������� �� ��������������� ������� 
    {
        if (!dead)
        {
            timeIterator += 0.5f;
            player.rb.velocity = new Vector2(Mathf.Log(timeIterator) * player.speed, player.rb.velocity.y);
        }
    }
}
