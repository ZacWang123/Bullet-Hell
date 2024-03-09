using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{
    public Vector2 bulletDirection;
    public float bulletSpeed;

    void OnEnable()
    {
        Invoke("Destroy", 3.5f);
    }

    void Start()
    {
        bulletSpeed = 12f;   
    }

    void Update()
    {
        transform.Translate(bulletDirection * bulletSpeed * Time.deltaTime);
    }

    public void SetBulletDirection(Vector2 direction)
    {
        bulletDirection = direction;
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
