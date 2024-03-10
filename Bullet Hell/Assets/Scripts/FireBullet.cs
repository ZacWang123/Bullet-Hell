using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    int numBullets;
    float startAngle, endAngle;
    float bulDirX;
    float bulDirY;
    float angle;
    float angleStep;

    void Start()
    {
        //InvokeRepeating("Pattern1", 0f, 0.3f);
        //InvokeRepeating("Pattern2", 0f, 0.1f);
        //InvokeRepeating("Pattern3", 0f, 0.25f);
        //InvokeRepeating("Pattern4", 0f, 0.1f);
        //InvokeRepeating("Pattern5", 0f, 0.1f);
        //InvokeRepeating("Pattern6", 0f, 0.5f);
        //InvokeRepeating("Pattern7", 0f, 0.05f);
        InvokeRepeating("PatternA", 0f, 0.3f);
    }

    void Pattern1()
    {
        numBullets = 27;
        startAngle = 0f;
        endAngle = 360f;

        angleStep = (endAngle - startAngle) / numBullets;
        angle = startAngle;

        for (int i = 0; i < numBullets + 1; i++) 
        {
            bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().bulletSpeed = 12f;
            bul.GetComponent<Bullet>().BulletDuration(3f);
            bul.GetComponent<Bullet>().SetBulletDirection(bulDir);
            angle += angleStep;
        }
    }

    void Pattern2()
    {
        for (int i = 0; i <= 2; i++)
        {
            bulDirX = transform.position.x + Mathf.Sin(((angle + 120f * i) * Mathf.PI) / 180f);
            bulDirY = transform.position.y + Mathf.Cos(((angle + 120f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().bulletSpeed = 12f;
            bul.GetComponent<Bullet>().BulletDuration(4f);
            bul.GetComponent<Bullet>().SetBulletDirection(bulDir);
        }

        angle += 10f;
        if (angle > 360f)
        {
            angle = 0f;
        }
    }

    void Pattern3()
    {
        for (int i = 0; i <= 59; i++)
        {
            bulDirX = transform.position.x + Mathf.Sin(((angle + 5f * i) * Mathf.PI) / 180f);
            bulDirY = transform.position.y + Mathf.Cos(((angle + 5f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().bulletSpeed = 12f;
            bul.GetComponent<Bullet>().BulletDuration(4f);
            bul.GetComponent<Bullet>().SetBulletDirection(bulDir);
        }

        angle += 10f;
        if (angle > 360f)
        {
            angle = 0f;
        }
    }

    void Pattern4()
    {
        for (int i = 0; i <= 2; i++)
        {
            bulDirX = transform.position.x + Mathf.Sin(((angle + 120f * i) * Mathf.PI) / 180f);
            bulDirY = transform.position.y + Mathf.Cos(((angle + 120f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().bulletSpeed = 12f;
            bul.GetComponent<Bullet>().BulletDuration(4f);
            bul.GetComponent<Bullet>().SetBulletDirection(bulDir);
            bul.GetComponent<Bullet>().DirectionDelay(1f, 60);
        }

        angle += 5f;
        if (angle > 360f)
        {
            angle = 0f;
        }
    }

    void Pattern5()
    {
        for (int i = 0; i <= 5; i++)
        {
            bulDirX = transform.position.x + Mathf.Sin(((angle + 60f * i) * Mathf.PI) / 180f);
            bulDirY = transform.position.y + Mathf.Cos(((angle + 60f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;
                
            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().bulletSpeed = 15f;
            bul.GetComponent<Bullet>().BulletDuration(3.5f);
            bul.GetComponent<Bullet>().SetBulletDirection(bulDir);
            bul.GetComponent<Bullet>().DirectionDelay(1.75f, 180);
        }

        angle += 5f;
        if (angle > 360f)
        {
            angle = 0f;
        }
    }

    void Pattern6()
    {
        for (int i = 0; i <= 35; i++)
        {
            bulDirX = transform.position.x + Mathf.Sin(((angle + 10f * i) * Mathf.PI) / 180f);
            bulDirY = transform.position.y + Mathf.Cos(((angle + 10f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().bulletSpeed = 8f;
            bul.GetComponent<Bullet>().BulletDuration(4f);
            bul.GetComponent<Bullet>().SetBulletDirection(bulDir);
            bul.GetComponent<Bullet>().SpeedDelay(1.5f, 24f);
        }

        angle += 2f;
        if (angle > 360f)
        {
            angle = 0f;
        }
    }

    void Pattern7()
    {
        for (int i = 0; i <= 1; i++)
        {
            bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            if (i == 1)
            {
                bulDir.x *= -1;
            }

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().bulletSpeed = 12f;
            bul.GetComponent<Bullet>().BulletDuration(4f);
            bul.GetComponent<Bullet>().SetBulletDirection(bulDir);
        }

        angle += 10f;
        if (angle > 360f)
        {
            angle = 0f;
        }
    }

    void PatternA()
    {

        bulDirX = 0;
        bulDirY = -90;

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector).normalized;
        GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
        bul.transform.position = new Vector3(10f,10f,0f);
        bul.transform.rotation = transform.rotation;
        bul.SetActive(true);
        bul.GetComponent<Bullet>().bulletSpeed = 12f;
        bul.GetComponent<Bullet>().BulletDuration(4f);
        bul.GetComponent<Bullet>().SetBulletDirection(bulDir);
    }

    void Update()
    {
    }
}
