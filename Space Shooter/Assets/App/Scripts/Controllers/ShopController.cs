using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Button[] shopButtons;
    [SerializeField] private TextMeshProUGUI[] shopButtonsText;
    [SerializeField] private SpriteRenderer player;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject menu;

    public void Back()
    {
        shop.SetActive(false);
        menu.SetActive(true);
    }

    void Awake()
    {
        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            if (PlayerPrefs.GetString($"{shopButtonsText[i]}", "Select") == "Selected")
            {
                player.sprite = shopButtons[i].GetComponent<Image>().sprite;
            }
        }
    }

    public void Blue1()
    {
        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            shopButtonsText[i].text = "Select";
            PlayerPrefs.SetString($"{shopButtonsText[i]}", "Select");
        }

        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            player.sprite = shopButtons[0].GetComponent<Image>().sprite;

            shopButtonsText[0].text = "Selected";
            PlayerPrefs.SetString($"{shopButtonsText[0]}", "Selected");
        }
    }

    public void Green1()
    {
        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            shopButtonsText[i].text = "Select";
            PlayerPrefs.SetString($"{shopButtonsText[i]}", "Select");
        }

        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            player.sprite = shopButtons[1].GetComponent<Image>().sprite;

            shopButtonsText[1].text = "Selected";
            PlayerPrefs.SetString($"{shopButtonsText[1]}", "Selected");
        }
    }

    public void Orange1()
    {
        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            shopButtonsText[i].text = "Select";
            PlayerPrefs.SetString($"{shopButtonsText[i]}", "Select");
        }

        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            player.sprite = shopButtons[2].GetComponent<Image>().sprite;

            shopButtonsText[2].text = "Selected";
            PlayerPrefs.SetString($"{shopButtonsText[2]}", "Selected");
        }
    }

    public void Red1()
    {
        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            shopButtonsText[i].text = "Select";
            PlayerPrefs.SetString($"{shopButtonsText[i]}", "Select");
        }

        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            player.sprite = shopButtons[3].GetComponent<Image>().sprite;

            shopButtonsText[3].text = "Selected";
            PlayerPrefs.SetString($"{shopButtonsText[3]}", "Selected");
        }
    }

    public void Blue2()
    {
        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            shopButtonsText[i].text = "Select";
            PlayerPrefs.SetString($"{shopButtonsText[i]}", "Select");
        }

        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            player.sprite = shopButtons[4].GetComponent<Image>().sprite;

            shopButtonsText[4].text = "Selected";
            PlayerPrefs.SetString($"{shopButtonsText[4]}", "Selected");
        }
    }

    public void Green2()
    {
        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            shopButtonsText[i].text = "Select";
            PlayerPrefs.SetString($"{shopButtonsText[i]}", "Select");
        }

        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            player.sprite = shopButtons[5].GetComponent<Image>().sprite;

            shopButtonsText[5].text = "Selected";
            PlayerPrefs.SetString($"{shopButtonsText[5]}", "Selected");
        }
    }

    public void Orange2()
    {
        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            shopButtonsText[i].text = "Select";
            PlayerPrefs.SetString($"{shopButtonsText[i]}", "Select");
        }

        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            player.sprite = shopButtons[6].GetComponent<Image>().sprite;

            shopButtonsText[6].text = "Selected";
            PlayerPrefs.SetString($"{shopButtonsText[6]}", "Selected");
        }
    }

    public void Red2()
    {
        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            shopButtonsText[i].text = "Select";
            PlayerPrefs.SetString($"{shopButtonsText[i]}", "Select");
        }

        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            player.sprite = shopButtons[7].GetComponent<Image>().sprite;

            shopButtonsText[7].text = "Selected";
            PlayerPrefs.SetString($"{shopButtonsText[7]}", "Selected");
        }
    }

    public void Blue3()
    {
        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            shopButtonsText[i].text = "Select";
            PlayerPrefs.SetString($"{shopButtonsText[i]}", "Select");
        }

        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            player.sprite = shopButtons[8].GetComponent<Image>().sprite;

            shopButtonsText[8].text = "Selected";
            PlayerPrefs.SetString($"{shopButtonsText[8]}", "Selected");
        }
    }

    public void Green3()
    {
        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            shopButtonsText[i].text = "Select";
            PlayerPrefs.SetString($"{shopButtonsText[i]}", "Select");
        }

        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            player.sprite = shopButtons[9].GetComponent<Image>().sprite;

            shopButtonsText[9].text = "Selected";
            PlayerPrefs.SetString($"{shopButtonsText[9]}", "Selected");
        }
    }

    public void Orange3()
    {
        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            shopButtonsText[i].text = "Select";
            PlayerPrefs.SetString($"{shopButtonsText[i]}", "Select");
        }

        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            player.sprite = shopButtons[10].GetComponent<Image>().sprite;

            shopButtonsText[10].text = "Selected";
            PlayerPrefs.SetString($"{shopButtonsText[10]}", "Selected");
        }
    }

    public void Red3()
    {
        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            shopButtonsText[i].text = "Select";
            PlayerPrefs.SetString($"{shopButtonsText[i]}", "Select");
        }

        for (int i = 0; i < shopButtonsText.Length; i++)
        {
            player.sprite = shopButtons[11].GetComponent<Image>().sprite;

            shopButtonsText[11].text = "Selected";
            PlayerPrefs.SetString($"{shopButtonsText[11]}", "Selected");
        }
    }
}
