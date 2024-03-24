using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed = 20;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 ObjectScreenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (ObjectScreenPosition.x >= Screen.width && x > 0)
        {
            x = 0;
        }

        if (ObjectScreenPosition.x <= 0 && x < 0)
        {
            x = 0;
        }

        if (ObjectScreenPosition.y >= Screen.height && y > 0)
        {
            y = 0;
        }

        if (ObjectScreenPosition.y <= 0 && y < 0)
        {
            y = 0;
        }

        rb.velocity = new Vector2(x, y).normalized * moveSpeed;
    }
}
