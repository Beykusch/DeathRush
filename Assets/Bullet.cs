using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int life = 3;
    public bool colEn = false;

    void Awake()
    {
        Destroy(gameObject,life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        colEn = true;
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        colEn = false;
    }
}
