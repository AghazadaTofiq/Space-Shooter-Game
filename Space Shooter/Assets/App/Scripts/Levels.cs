using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;
    [SerializeField] private Image[] lockImages;
    [SerializeField] private GameObject levels;
    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private int lastSceneIndex;
    [SerializeField] private GameObject menu;

    private void Start()
    {
        PlayerPrefs.SetString("0", "Unlocked");

        for (int i = 0; i < lockImages.Length; i++)
        {
            if (PlayerPrefs.HasKey($"{0 + i}"))
            {
                if (PlayerPrefs.GetString($"{0 + i}") == "Unlocked")
                {
                    lockImages[i].enabled = false;
                }
                else
                {
                    lockImages[i].enabled = true;
                }
            }
            else
            {
                PlayerPrefs.GetString($"{0 + i}", "Locked");
            }
            if (lockImages[i].enabled)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
        Time.timeScale = 1;
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == lastSceneIndex)
        {
            ui.SetActive(false);
            gameOver.SetActive(false);
            menu.SetActive(true);
        }
        else
        {
            for (int i = 0; i < lockImages.Length; i++)
            {
                lockImages[SceneManager.GetActiveScene().buildIndex + 1].enabled = false;
                levelButtons[SceneManager.GetActiveScene().buildIndex + 1].interactable = true;
            }
            PlayerPrefs.SetString($"{SceneManager.GetActiveScene().buildIndex + 1}", "Unlocked");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Back()
    {
        levels.SetActive(false);
        menu.SetActive(true);
    }
}
