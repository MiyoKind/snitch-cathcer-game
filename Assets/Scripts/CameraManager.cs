using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
#pragma warning disable CS0108 // „лен скрывает унаследованный член: отсутствует новое ключевое слово
    public static CameraManager camera;

#pragma warning restore CS0108 // „лен скрывает унаследованный член: отсутствует новое ключевое слово
    Player player;
    private void Awake()
    {
        if (camera == null)
        {
            camera = this;
        }
    }

    private void Start()
    {
        player = Player.player;
    }

    public void MoveCameraWithPlayer()
    {
        transform.position = new Vector3(player.transform.position.x ,transform.position.y, transform.position.z);
    }
}
