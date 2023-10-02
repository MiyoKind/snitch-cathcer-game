using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float lenght, startpos; //����� � ��������� ������� ������� 
    public GameObject cam; //������
    public float parallaxEffect; //��������� ��� �������
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x; //����������� ��������� �������
        lenght = GetComponent<SpriteRenderer>().bounds.size.x; //������ ����� ������� �� �
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Position = cam.transform.position;
        float temp = (Position.x * (1 - parallaxEffect)); //��� ������ ������������ ������������ ������
        float dist = (Position.x * parallaxEffect); //�� ��� ������ �� ������������ �� ��������� �����

        Vector3 NewPosition = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        transform.position = NewPosition;
        //if (temp > startpos + (lenght/2)) startpos += lenght;
        
        //else if (temp < startpos - (lenght / 2))
        //{
        //    startpos -= lenght;
        //}
    }
}

