using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public GameObject player;
    public Vector2 defaultVector;
    public Vector2 bulletDirection;
    public Vector2 bulletOriginLocation;
    public Vector2 bulletTargetLocation;
    public float defaultFloat;
    public float bulletSpeed;
    public float speedChange;
    public float timePassed;
    public float angleChange;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    IEnumerator WaitForFunction(float waitTime, string action, Vector2 vectorValue, float floatValue)
    {
        yield return new WaitForSeconds(waitTime);
        if (action == "Change Speed")
        {
            ChangeSpeed(floatValue);
        }

        if (action == "Change Rotation")
        {
            ChangeRotation(floatValue);
        }

        if (action == "Change Target")
        {
            TargetPlayer(vectorValue);
        }

        if (action == "Change Location")
        {
            ChangeLocation(vectorValue);
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
        StartCoroutine(WaitForFunction(waitTime, "Change Speed", defaultVector, newBulletSpeed));
    }

    public void ChangeSpeed(float speedChange)
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
        StartCoroutine(WaitForFunction(waitTime, "Change Rotation", defaultVector, angle));
    }

    public void DelayTargetPlayer(float waitTime, Vector2 originLocation)
    {
        StartCoroutine(WaitForFunction(waitTime, "Change Target", originLocation, defaultFloat));
    }

    public void DirectionDelay(float waitTime, Vector2 targetLocation)
    {
        StartCoroutine(WaitForFunction(waitTime, "Change Location", targetLocation, defaultFloat));
    }

    public void ChangeLocation(Vector2 targetLocation)
    {
        bulletDirection = new Vector2(targetLocation.x, targetLocation.y);
    }

    public void ChangeRotation(float angleChange)
    {
        bulletDirection = rotate(bulletDirection, angleChange);
    }

    public void TargetPlayer(Vector2 originLocation)
    {
        bulletOriginLocation = originLocation;
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
