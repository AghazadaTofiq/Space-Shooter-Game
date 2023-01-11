using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropdownController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] menuTexts;
    [SerializeField] private TMP_Dropdown dropdown;

    private List<string> texts = new List<string>();

    void Start()
    {
        dropdown.options.Clear();

        texts.Add("English");
        texts.Add("Azerbaijani");
        texts.Add("Chinese");
        texts.Add("French");
        texts.Add("German");
        texts.Add("Hindi");
        texts.Add("Italian");
        texts.Add("Russian");
        texts.Add("Spanish");
        texts.Add("Turkish");

        foreach (var text in texts)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = text });
        }

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    private void DropdownItemSelected(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;

        for (int i = 0; i < menuTexts.Length; i++)
        {
            menuTexts[i].text = dropdown.options[index].text;
        }

    }
}
