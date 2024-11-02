using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiddleArea : MonoBehaviour
{
    BoxCollider2D _colmid;


    void Start()
    {
        _colmid = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _colmid.enabled = !_colmid.enabled;
        }
    }
}
