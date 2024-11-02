using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int life = 3;

    void Awake()
    {
        Destroy(gameObject,life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
