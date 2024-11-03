using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    //variables for Shoot()
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30;

    //variables for UpdateReqCombo
    private int inputInt;
    private int count;
    private int reqCombo1, reqCombo2, reqCombo3;

    public SpriteRenderer[] directionSprites; // Array of SpriteRenderers to show each direction
    public Sprite[] sprites; // Array of possible sprites for each direction (e.g., 0=Up, 1=Left, 2=Down, 3=Right)

    void Start()
    {
        UpdateReqCombo();
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            inputInt = 1;
            Bruh();
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            inputInt = 2;
            Bruh();
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            inputInt = 3;
            Bruh();
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
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

        print("Combo Sequence: " + reqCombo1 + ", " + reqCombo2 + ", " + reqCombo3);

        // Update direction sprites based on new combo
        UpdateDirectionSprite(0, reqCombo1); // First direction
        UpdateDirectionSprite(1, reqCombo2); // Second direction
        UpdateDirectionSprite(2, reqCombo3); // Third direction


    }

    private void UpdateDirectionSprite(int index, int direction)
    {
        if (index < directionSprites.Length && direction - 1 < sprites.Length)
        {
            directionSprites[index].sprite = sprites[direction - 1];
        }
    }
}
