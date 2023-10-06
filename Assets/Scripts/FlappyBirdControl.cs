using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdControl : MonoBehaviour
{
    public float jumpForce = 5.0f; // Сила прыжка

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        // Обработка щелчка мышью
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Добавляем вертикальную силу для прыжка
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    
}
