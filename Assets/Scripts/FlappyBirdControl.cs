using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdControl : MonoBehaviour
{
    public float jumpForce = 5.0f; // ���� ������

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        // ��������� ������ �����
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void Jump()
    {
        // ��������� ������������ ���� ��� ������
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    
}
