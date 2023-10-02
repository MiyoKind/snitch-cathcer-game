using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float lenght, startpos; //длина и начальная позиция спрайта 
    public GameObject cam; //камера
    public float parallaxEffect; //переменна для эффекта
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x; //определение начальной позиции
        lenght = GetComponent<SpriteRenderer>().bounds.size.x; //узнаем длину спрайта по х
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Position = cam.transform.position;
        float temp = (Position.x * (1 - parallaxEffect)); //как далеко продвинулись относительно камеры
        float dist = (Position.x * parallaxEffect); //то как далеко мы продвинулись от начальной точки

        Vector3 NewPosition = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        transform.position = NewPosition;
        //if (temp > startpos + (lenght/2)) startpos += lenght;
        
        //else if (temp < startpos - (lenght / 2))
        //{
        //    startpos -= lenght;
        //}
    }
}

