using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public GameObject player;
    public Vector2 bulletDirection;
    public Vector2 bulletOriginLocation;
    public float bulletSpeed;
    public float speedChange;
    public float timePassed;
    public float angleChange;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    IEnumerator WaitForFunction(float waitTime, string action)
    {
        yield return new WaitForSeconds(waitTime);
        if (action == "Change Speed")
        {
            ChangeSpeed();
        }

        if (action == "Change Direction")
        {
            ChangeRotation();
        }

        if (action == "Change Target")
        {
            ChangeDirection();
        }
    }

    public void BulletDuration(float bulletDuration)
    {
        Invoke("Destroy", bulletDuration);
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

    public void RotationDelay(float waitTime, float angle)
    {
        angleChange = angle;
        StartCoroutine(WaitForFunction(waitTime, "Change Direction"));
    }

    public void DirectionDelay(float waitTime, Vector2 originLocation)
    {
        bulletOriginLocation = originLocation;
        StartCoroutine(WaitForFunction(waitTime, "Change Target"));
    }

    public void ChangeRotation()
    {
        bulletDirection = rotate(bulletDirection, angleChange);
    }

    public void ChangeDirection()
    {
        bulletDirection = new Vector2(player.transform.position.x - bulletOriginLocation.x, player.transform.position.y - bulletOriginLocation.y).normalized * 4;
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
