using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreLabel;
    [SerializeField] public TextMeshProUGUI highScoreLabel;
    [SerializeField] public TextMeshProUGUI remainingEnemiesLabel;
    [SerializeField] public int enemyCount;
    [SerializeField] public GameObject gameOver;
    [SerializeField] public GameObject restart;
    [SerializeField] public GameObject nextLevel;

    public int score;
    public int highScore;
    public Color red = new Color();
    public Color green = new Color();

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        highScoreLabel.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();

        red = new(1, 0, 0, 0.4f);
        green = new(0, 1, 0, 0.4f);
    }
}
