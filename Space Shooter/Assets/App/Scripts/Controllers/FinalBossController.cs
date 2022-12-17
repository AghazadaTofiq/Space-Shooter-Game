using UnityEngine;
using UnityEngine.UI;

public class FinalBossController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzleLeft;
    [SerializeField] private Transform muzzleRight;

    private float shootTimer;

    private bool moveRight = true;
    private bool moveLeft = false;

    private void FixedUpdate()
    {
        if(moveRight)
        {
            rb.velocity = Vector2.right/2;
        }
        if(moveLeft)
        {
            rb.velocity = Vector2.left/2;
        }

        shootTimer += Time.fixedDeltaTime;

        if (shootTimer > Random.Range(3, 6))
        {
            shootTimer = 0f;

            Instantiate(bulletPrefab, muzzleLeft.position, Quaternion.identity);
            Instantiate(bulletPrefab, muzzleRight.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("LeftWall"))
        {
            moveLeft = false;
            transform.position += new Vector3(0,-0.5f,0);
            if(transform.position.y==-3.5f)
            {
                UIManager.Instance.gameOver.GetComponent<Image>().color = UIManager.Instance.red;
                UIManager.Instance.gameOver.SetActive(true);
                UIManager.Instance.restart.SetActive(true);
                Time.timeScale = 0;
            }
            moveRight = true;
        }
        if (other.CompareTag("RightWall"))
        {
            moveRight = false;
            transform.position += new Vector3(0, -0.5f, 0);
            if (transform.position.y == -3.5f)
            {
                UIManager.Instance.gameOver.GetComponent<Image>().color = UIManager.Instance.red;
                UIManager.Instance.gameOver.SetActive(true);
                UIManager.Instance.restart.SetActive(true);
                Time.timeScale = 0;
            }
            moveLeft = true;
        }
        if(other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            healthBar.fillAmount -= 0.01f;
            if(healthBar.fillAmount==0)
            {
                Destroy(gameObject);
                UIManager.Instance.gameOver.GetComponent<Image>().color = UIManager.Instance.green;
                UIManager.Instance.gameOver.SetActive(true);
                UIManager.Instance.nextLevel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
