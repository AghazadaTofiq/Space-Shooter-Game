using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
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
        if (PlayerPrefs.GetInt("Cash") >= PlayerPrefs.GetInt("Movement Price", 300) && PlayerPrefs.GetFloat("Speed", 5) != 10)
        {
            PlayerPrefs.SetFloat("Speed", PlayerPrefs.GetFloat("Speed", 100) + 10);
            PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") - PlayerPrefs.GetInt("Movement Price"));
            bank.text = "Bank: " + PlayerPrefs.GetInt("Cash").ToString();
            PlayerPrefs.SetInt("Movement Price", PlayerPrefs.GetInt("Movement Price") + 150);
            movementPriceText.text = PlayerPrefs.GetInt("Movement Price", 300).ToString();
        }
    }

    public void FasterShooting()
    {
        if ((PlayerPrefs.GetInt("Cash") >= PlayerPrefs.GetInt("Shooting Price", 300)) && PlayerPrefs.GetFloat("Bullet", 2) != 1)
        {
            PlayerPrefs.SetFloat("Bullet", PlayerPrefs.GetFloat("Bullet", 2) - 0.1f);        
            PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") - PlayerPrefs.GetInt("Shooting Price"));
            bank.text = "Bank: " + PlayerPrefs.GetInt("Cash").ToString();
            PlayerPrefs.SetInt("Shooting Price", PlayerPrefs.GetInt("Shooting Price") + 150);
            shootingPriceText.text = PlayerPrefs.GetInt("Shooting Price", 300).ToString();
        }
    }

    public void Back()
    {
        upgrades.SetActive(false);
        menu.SetActive(true);
    }
}
