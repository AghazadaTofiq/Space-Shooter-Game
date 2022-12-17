using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 7;
    [SerializeField] private float lifeTime = 3;
    [SerializeField] private Rigidbody2D rb;

    private void DestroySelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void Awake()
    {
        Invoke("DestroySelf", lifeTime);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.CompareTag("PlayerBullet") && other.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
