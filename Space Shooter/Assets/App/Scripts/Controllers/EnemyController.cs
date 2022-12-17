using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;

    private float shootTimer;

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, -speed);

        if (gameObject.transform.position.y < -3.5f)
        {
            UIManager.Instance.gameOver.GetComponent<Image>().color = UIManager.Instance.red;
            UIManager.Instance.gameOver.SetActive(true);
            UIManager.Instance.restart.SetActive(true);
            Time.timeScale = 0;
        }

        shootTimer += Time.fixedDeltaTime;

        if (shootTimer > Random.Range(3,6))
        {
            shootTimer = 0f;

            Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);

            UIManager.Instance.score += Random.Range(3, 5);
            UIManager.Instance.scoreLabel.text = "Score: " + UIManager.Instance.score.ToString();
            PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash", 0) + UIManager.Instance.score);

            if(PlayerPrefs.GetInt("HighScore")< UIManager.Instance.score)
            {
                UIManager.Instance.highScore = UIManager.Instance.score;
                PlayerPrefs.SetInt("HighScore", UIManager.Instance.highScore);
                UIManager.Instance.highScoreLabel.text = "High Score: " + UIManager.Instance.highScore.ToString();
            }

            UIManager.Instance.enemyCount--;
            UIManager.Instance.remainingEnemiesLabel.text = "Remaining Enemies " + UIManager.Instance.enemyCount.ToString();
            if(UIManager.Instance.enemyCount==0)
            {
                UIManager.Instance.gameOver.GetComponent<Image>().color = UIManager.Instance.green;
                UIManager.Instance.gameOver.SetActive(true);
                UIManager.Instance.nextLevel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

}
