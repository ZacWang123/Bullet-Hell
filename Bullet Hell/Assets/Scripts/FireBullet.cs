using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    int numBullets;
    float startAngle, endAngle;
    Vector2 bulletMoveDirection;
    float bulDirX;
    float bulDirY;
    float angle;
    float angleStep;
    float timer;

    void Start()
    {
        InvokeRepeating("Pattern1", 0f, 0.5f);
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
            bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 90f);
            bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 90f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetBulletDirection(bulDir);
            print(angle);
            angle += angleStep;
        }
    }


    void Update()
    {
    }
}
