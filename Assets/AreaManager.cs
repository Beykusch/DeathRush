using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public GameObject UpperLane;
    public GameObject MiddleLane;
    public GameObject LowerLane;

    BoxCollider2D _up;
    BoxCollider2D _mid;
    BoxCollider2D _low;

    void Start()
    {
        _up = UpperLane.GetComponent<BoxCollider2D>();
        _mid = MiddleLane.GetComponent<BoxCollider2D>();
        _low = LowerLane.GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _up.enabled = true;
            _mid.enabled = false;
            _low.enabled = false;
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            _up.enabled = false;
            _mid.enabled = true;
            _low.enabled = false;
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            _up.enabled = false;
            _mid.enabled = false;
            _low.enabled = true;
        }
    }
}
