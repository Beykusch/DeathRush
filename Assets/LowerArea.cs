using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LowerArea : MonoBehaviour
{
    BoxCollider2D _collower;


    void Start()
    {
        _collower = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _collower.enabled = !_collower.enabled;
        }
    }
}
