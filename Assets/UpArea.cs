using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpArea : MonoBehaviour
{
    BoxCollider2D _colup;
    
    
    void Start()
    {
        _colup = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _colup.enabled = !_colup.enabled;
        }
    }
}
