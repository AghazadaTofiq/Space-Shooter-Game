using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;
    [SerializeField] private int lives = 3;
    [SerializeField] private TextMeshProUGUI livesLabel;
    [SerializeField] public AudioSource shootMusic;
    [SerializeField] public AudioClip shootSound;

    private Color playerColor = new Color();
    private Collider2D playerCollider = new Collider2D();

    private void Start()
    {
        playerColor = GetComponent<SpriteRenderer>().color;
        playerCollider = GetComponent<Collider2D>();
    }

    private float shootTimer;


#if UNITY_EDITOR
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * PlayerPrefs.GetFloat("Speed", 100) * Time.fixedDeltaTime, 0);

        shootTimer += Time.deltaTime;

        if (shootTimer > PlayerPrefs.GetFloat("Bullet", 2f))
        {
            shootTimer = 0f;
            shootMusic.PlayOneShot(shootSound);
            Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
        }
    }
#endif

#if UNITY_ANDROID || UNITY_IOS
    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary)
            {
                if (touch.position.x > Screen.width / 2)
                {
                    rb.velocity = new Vector2(PlayerPrefs.GetFloat("Speed", 100) * Time.fixedDeltaTime, 0);
                }
                if (touch.position.x < Screen.width / 2)
                {
                    rb.velocity = new Vector2(-PlayerPrefs.GetFloat("Speed", 100) * Time.fixedDeltaTime, 0);
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        shootTimer += Time.fixedDeltaTime;

        if (shootTimer > PlayerPrefs.GetFloat("Bullet", 2f))
        {
            shootTimer = 0f;
            shootMusic.PlayOneShot(shootSound);
            Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
        }
    }
#endif

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet") || other.CompareTag("Meteors"))
        {
            StartCoroutine(ReSpawn());
            Destroy(other.gameObject);
            lives--;
            livesLabel.text = "Lives " + lives.ToString();
            if (lives == 0)
            {
                UIManager.Instance.gameOver.GetComponent<Image>().color = UIManager.Instance.red;
                UIManager.Instance.gameOver.SetActive(true);
                UIManager.Instance.restart.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (other.CompareTag("Hearts"))
        {
            Destroy(other.gameObject);
            lives++;
            livesLabel.text = "Lives " + lives.ToString();
        }
    }

    private IEnumerator ReSpawn()
    {
        playerCollider.enabled = false;
        GetComponent<SpriteRenderer>().color = playerColor * 0.25f;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = playerColor * 0.5f;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = playerColor * 0.25f;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = playerColor * 0.5f;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = playerColor * 0.25f;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = playerColor * 1;
        playerCollider.enabled = true;
    }
}
