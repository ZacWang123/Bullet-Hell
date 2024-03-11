using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    Vector2 screenBounds;
    bool reverseAngle;
    int numBullets;
    int openSpace;
    float startAngle, endAngle;
    float bulDirX;
    float bulDirY;
    float angle;
    float angleStep;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 2, Screen.height, Camera.main.transform.position.z));
        //StartCoroutine(StartPatterns());
        //InvokeRepeating("Pattern1", 0f, 0.3f);
        //InvokeRepeating("Pattern2", 0f, 0.1f);
        //InvokeRepeating("Pattern3", 0f, 0.25f);
        //InvokeRepeating("Pattern4", 0f, 0.1f);
        //InvokeRepeating("Pattern5", 0f, 0.1f);
        //InvokeRepeating("Pattern6", 0f, 0.5f);
        //InvokeRepeating("Pattern7", 0f, 0.05f);
        //InvokeRepeating("Pattern8", 0f, 0.1f);
        InvokeRepeating("Pattern9", 0f, 2f);
        //Invoke("PatternA", 0f);
        //Invoke("PatternB", 0f);
    }
    IEnumerator StartPatterns()
    {
        InvokeRepeating("Pattern1", 0f, 0.3f);
        yield return new WaitForSeconds(5);
        CancelInvoke();
        yield return new WaitForSeconds(3);
        InvokeRepeating("Pattern2", 0f, 0.1f);
        yield return new WaitForSeconds(5);
        CancelInvoke();
        yield return new WaitForSeconds(3);
        InvokeRepeating("Pattern3", 0f, 0.25f);
        yield return new WaitForSeconds(5);
        CancelInvoke();
        yield return new WaitForSeconds(3);
        InvokeRepeating("Pattern4", 0f, 0.1f);
        yield return new WaitForSeconds(5);
        CancelInvoke();
        yield return new WaitForSeconds(3);
        InvokeRepeating("Pattern5", 0f, 0.1f);
        yield return new WaitForSeconds(5);
        CancelInvoke();
        yield return new WaitForSeconds(3);
        InvokeRepeating("Pattern6", 0f, 0.5f);
        yield return new WaitForSeconds(5);
        CancelInvoke();
        yield return new WaitForSeconds(3);
        InvokeRepeating("Pattern7", 0f, 0.05f);
        yield return new WaitForSeconds(5);
        CancelInvoke();
        yield return new WaitForSeconds(3);
        InvokeRepeating("Pattern8", 0f, 0.1f);
        yield return new WaitForSeconds(5);
        CancelInvoke();
        yield return new WaitForSeconds(3);
        InvokeRepeating("PatternA", 0f, 1f);
        yield return new WaitForSeconds(5);
        CancelInvoke();
        yield return new WaitForSeconds(3);
        InvokeRepeating("PatternB", 0f, 1f);
        yield return new WaitForSeconds(5);
        CancelInvoke();
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
            bul.GetComponent<Bullet>().RotationDelay(1f, 60);
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
            bul.GetComponent<Bullet>().RotationDelay(1.75f, 180);
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

    void Pattern8()
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

        if (reverseAngle)
        {
            angle -= 10;
        }
        else
        {
            angle += 10;
        }

        if (angle == 180f)
        {
            reverseAngle = true;
        }
        else if (angle == 0)
        {
            reverseAngle = false;

        }
    }

    void Pattern9()
    {
        numBullets = 27;
        startAngle = 0f;
        endAngle = 360f;
            
        angleStep = (endAngle - startAngle) / numBullets;
        angle = startAngle;

        for (int i = 0; i < numBullets + 1; i++)
        {
            bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().bulletSpeed = 12f;
            bul.GetComponent<Bullet>().BulletDuration(3f);
            bul.GetComponent<Bullet>().SetBulletDirection(bulDir);
            bul.GetComponent<Bullet>().SpeedDelay(0.3f, 0f);
            bul.GetComponent<Bullet>().SpeedDelay(0.7f, 8f);
            bul.GetComponent<Bullet>().DirectionDelay(0.5f, transform.position);
            angle += angleStep;
        }
    }

    void PatternA()
    {
        numBullets = 24;
        bulDirX = 0;
        bulDirY = -90;
        openSpace = Random.Range(2, numBullets - 1);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector).normalized;

        for (int i = 1; i < numBullets; i++)
        {
            if (i < (openSpace - 1) || i > openSpace + 1)
            {
                GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = new Vector3(screenBounds.x - (i * screenBounds.x * 2 / numBullets), screenBounds.y, 0f);
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().bulletSpeed = 12f;
                bul.GetComponent<Bullet>().BulletDuration(4f);
                bul.GetComponent<Bullet>().SetBulletDirection(bulDir);
            }
        }
    }

    void PatternB()
    {
        numBullets = 20;
        bulDirX = -90;
        bulDirY = 0;
        openSpace = Random.Range(2, numBullets - 1);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector).normalized;

        for (int i = 1; i < numBullets; i++)
        {
            if (i < (openSpace - 1) || i > openSpace + 1)
            {
                GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = new Vector3(screenBounds.x, screenBounds.y - (i * screenBounds.y * 2 / numBullets), 0f);
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().bulletSpeed = 16f;
                bul.GetComponent<Bullet>().BulletDuration(5f);
                bul.GetComponent<Bullet>().SetBulletDirection(bulDir);
            }
        }
    }


    void Update()
    {
    }
}
