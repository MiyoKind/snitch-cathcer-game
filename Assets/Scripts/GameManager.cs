using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int accelRate;
    public ShopManager[] shops;
    public ParallaxController parallaxController;
    public static GameManager gameManager;
    public GameObject startMenu;
    public GameObject gameplayMenu;
    public TextMeshProUGUI statMoney;
    public TextMeshProUGUI statLength;
    public NormalMusic normal;
    public AudioSource musicSourceGame;
    public AudioSource musicSourceMenu;
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
    public bool musicStatus = false;
    public bool soundStatus;
    public bool dead = false;
    public AudioSource[] audios;
    public Button soundButton;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }
    private void Start()
    {
        //Debug.Log(Application.persistentDataPath);
        SaveSystem.ss.LoadGame();
        player = Player.player;
        enemyCreator = EnemyCreator.enemyCreator;
        lowerBorder = Border.lowerBorder;
        upperBorder = Border.upperBorder;
        Time.timeScale = 0;
        player.ChangeSkin(currentSkin);
        statMoney.text = "���� ��������: " + money;
        statLength.text = "��� ������: " + record + " �";
        timeIterator = Mathf.Exp(1);
        dead = false;
        OnOffMusic();

    }

    public void StartGame()
    { 
        Time.timeScale = 1;
        player.StartMoving();
        startMenu.SetActive(false);
        gameplayMenu.SetActive(true);
        but.GameObject().SetActive(true);
        InvokeRepeating("Accelerate", accelRate, accelRate);
        TurnOffAllSounds();
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
        musicSourceGame.Stop();
        TurnOffAllSounds();
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

        musicSourceGame.enabled = musicStatus;
        musicSourceMenu.enabled = musicStatus;


        if (but.buttonPressed)
        {
            player.Jump();
        }

    }

    public void Accelerate() //��������� �� ��������������� ������� 
    {
        if (!dead)
        {
            timeIterator += 0.1f;
            player.rb.velocity = new Vector2(Mathf.Log(timeIterator) * player.speed, player.rb.velocity.y);
        }
    }

    public void OnOffMusic() // ���������/���������� ������
    {
        musicStatus = !musicStatus;

        if (musicStatus)
        {
            musicSourceGame.Play(); // �������� ������
            musicSourceMenu.Play(); // �������� ������
        }
        else
        {
            musicSourceGame.Stop(); // ��������� ������
            musicSourceMenu.Stop(); // ��������� ������
        }

        // ��������� ��������� ������ � PlayerPrefs
        PlayerPrefs.SetInt("MusicEnabled", musicStatus ? 1 : 0);
        PlayerPrefs.Save();
        SaveSystem.ss.SaveGame();
        Debug.Log("Music Status: " + musicStatus);
    }

    public void TurnOffAllSounds()
    {

        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        soundStatus = !soundStatus;
        if (!soundStatus)
        {
            
            
            foreach (AudioSource audioSource in allAudioSources)
            {
                audioSource.enabled = false;
            }
        }
        

        // ��������� ��������� ������ � PlayerPrefs
        PlayerPrefs.SetInt("MusicEnabled", soundStatus ? 1 : 0);
        PlayerPrefs.Save();
        SaveSystem.ss.SaveGame();
        Debug.Log("Music Status: " + soundStatus);
    }

}
