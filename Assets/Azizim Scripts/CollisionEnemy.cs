﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            DedeKayma.instance.DedeAzalt();
            Destroy(col.gameObject);

        }


    }
}
