using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public Vector2 bulletDirection;
    public float bulletSpeed;
    public float speedChange;
    public float timePassed;
    public float angleChange;

    IEnumerator WaitForFunction(float waitTime, string action)
    {
        yield return new WaitForSeconds(waitTime);
        if (action == "Change Speed")
        {
            ChangeSpeed();
        }

        if (action == "Change Direction")
        {
            ChangeDirection();
        }
    }
    void OnEnable()
    {
    }

    public void BulletDuration(float bulletDuration)
    {
        Invoke("Destroy", bulletDuration);
    }
    void Start()
    {
    }

    void Update()
    {
        transform.Translate(bulletDirection * bulletSpeed * Time.deltaTime);
    }

    public void SpeedDelay(float waitTime, float newBulletSpeed)
    {
        speedChange = newBulletSpeed;
        StartCoroutine(WaitForFunction(waitTime, "Change Speed"));
    }

    public void ChangeSpeed()
    {
        bulletSpeed = speedChange;
    }
    public void SetBulletDirection(Vector2 direction)
    {
        bulletDirection = direction;
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    public void DirectionDelay(float waitTime, float angle)
    {
        angleChange = angle;
        StartCoroutine(WaitForFunction(waitTime, "Change Direction"));
    }

    public void ChangeDirection()
    {
        bulletDirection = rotate(bulletDirection, angleChange);
    }

    public static Vector2 rotate(Vector2 v, float degrees)
    {
        float radian = degrees * Mathf.Deg2Rad;

        return new Vector2(
            v.x * Mathf.Cos(radian) - v.y * Mathf.Sin(radian),
            v.x * Mathf.Sin(radian) + v.y * Mathf.Cos(radian)
        );
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
