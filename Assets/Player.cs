using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables for Shoot()
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    //variables for UpdateReqCombo
    private int inputInt;
    private int count;
    private int reqCombo1, reqCombo2, reqCombo3;

    void Start()
    {
        UpdateReqCombo();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            inputInt = 1;
            Bruh();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            inputInt = 2;
            Bruh();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            inputInt = 3;
            Bruh();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            inputInt = 4;
            Bruh();
        }
    }

    public void Bruh()
    {
        switch (count)
        {
            case 0:

                if (inputInt == reqCombo1)
                {
                    count++;
                }

                break;

            case 1:

                if (inputInt == reqCombo2)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }

                break;

            case 2:

                if (inputInt == reqCombo3)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }

                if (count >= 3)
                {
                    Shoot();
                    UpdateReqCombo();
                    count = 0;
                    Bruh();
                }

                break;

        }

    }

    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawnPoint.right * bulletSpeed;
    }

    public void UpdateReqCombo()
    {
        reqCombo1 = Random.Range(1, 5);
        reqCombo2 = Random.Range(1, 5);
        reqCombo3 = Random.Range(1, 5);

        print(reqCombo1);
        print(reqCombo2);
        print(reqCombo3);

        //prints will change sprites
    }
}
