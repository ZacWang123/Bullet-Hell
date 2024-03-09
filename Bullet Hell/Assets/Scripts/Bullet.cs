using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public Vector2 bulletDirection;
    public float bulletSpeed;
    public float timePassed;

    IEnumerator WaitForFunction(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ChangeDirection();
    }
    
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

    public void DirectionDelay(float waitTime)
    {
        StartCoroutine(WaitForFunction(waitTime));
    }

    public void ChangeDirection()
    {
        float tempX = bulletDirection.x;
        float tempY = bulletDirection.y;
        bulletDirection.x = tempY * -1;
        bulletDirection.y = tempX;
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
