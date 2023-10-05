using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool Top;
    private bool isLevitating = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.gravityScale *= -1;
        }
    }
    
    public void Rotate()
    {
        if (Top == false) {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        Top = !Top;
        Update();

    }

    IEnumerator RevertGravityAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.gravityScale *= -1; // Вернуть гравитацию.
        isLevitating = false; // Установить флаг левитации обратно в false.
    }


}
