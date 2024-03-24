using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    bool playerVulnerable = true;
    int health = 5;
    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    Renderer playerRenderer;
    Rigidbody2D rb;

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
        Destroy(rb);
        Application.Quit();
    }

    void ChangeColour(float red, float blue, float green, float alpha)
    {
        playerRenderer.material.color = new Color(red, blue, green, alpha);
    }

    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = EmptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = FullHeart;
        }
    }
}
