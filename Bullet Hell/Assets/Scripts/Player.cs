using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int health = 5;
    float moveSpeed = 15;
    bool playerVulnerable = true;
    Rigidbody2D rb;
    Renderer playerRenderer;


    IEnumerator WaitForInvulnerability()
    {
        yield return new WaitForSeconds(2);
        ChangeColour(1f, 1f, 1f, 2.5f);
        playerVulnerable = true;
    }

    void Start()
    {
        
    }

    private void Awake()
    {
        playerRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Damage(int damage = 1)
    {
        health -= damage;
        if (health <= 0)
        {
            PlayerDead();
        }
        StartCoroutine(WaitForInvulnerability());
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Bullet")) && playerVulnerable)
        {
            playerVulnerable = false;
            ChangeColour(1f, 1f, 1f, 0.4f);
            Damage();

        }
    }

    void PlayerDead()
    {
        Debug.Log(rb.name + " has died.");
        Application.Quit();
        Destroy(rb);
    }

    void ChangeColour(float red, float blue, float green, float alpha)
    {
        playerRenderer.material.color = new Color(red, blue, green, alpha);
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(x, y).normalized * moveSpeed;
    }
    void Update()
    {
        
    }
}
