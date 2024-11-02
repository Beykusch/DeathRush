using UnityEngine;

public class ChangeYPosition : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            transform.position = new Vector3(transform.position.x, 2.93f, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            
            transform.position = new Vector3(transform.position.x, 0.63f, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            
            transform.position = new Vector3(transform.position.x, -1.67f, transform.position.z);
        }
    }
}