using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float coolDowntime;
    [SerializeField] private int movementPrice;
    [SerializeField] private int shootingPrice;
    [SerializeField] private TextMeshProUGUI movementPriceText;
    [SerializeField] private TextMeshProUGUI shootingPriceText;
    [SerializeField] private TextMeshProUGUI bank;
    [SerializeField] private GameObject upgrades;
    [SerializeField] private GameObject menu;

    private void Awake()
    {
        movementPriceText.text = PlayerPrefs.GetInt("Movement Price", 300).ToString();
        shootingPriceText.text = PlayerPrefs.GetInt("Shooting Price", 300).ToString();
        bank.text = "Bank: " + PlayerPrefs.GetInt("Cash").ToString();
    }

    public void FasterMovement()
    {
        if (PlayerPrefs.GetInt("Cash") >= PlayerPrefs.GetInt("Movement Price", 300))
        {
            PlayerPrefs.SetFloat("Speed", PlayerPrefs.GetFloat("Speed", speed) + 0.5f);
            PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") - 300);
            PlayerPrefs.SetInt("Movement Price", PlayerPrefs.GetInt("Movement Price") + 150);
        }
    }

    public void FasterShooting()
    {
        if (PlayerPrefs.GetInt("Cash") >= PlayerPrefs.GetInt("Shooting Price", 300))
        {
            PlayerPrefs.SetFloat("Bullet", PlayerPrefs.GetFloat("Bullet", coolDowntime) - 0.1f);
            PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") - 300);
            PlayerPrefs.SetInt("Shooting Price", PlayerPrefs.GetInt("Shooting Price") + 150);
        }
    }

    public void Back()
    {
        upgrades.SetActive(false);
        menu.SetActive(true);
    }
}
