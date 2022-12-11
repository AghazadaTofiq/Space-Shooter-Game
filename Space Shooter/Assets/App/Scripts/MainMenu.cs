using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject instructions;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject upgrades;
    [SerializeField] private GameObject levels;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject pause;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void Play()
    {
        menu.SetActive(false);
        ui.SetActive(true);
        Time.timeScale = 1;
    }

    public void Instructions()
    {
        menu.SetActive(false);
        instructions.SetActive(true);
    }

    public void Options()
    {
        menu.SetActive(false);
        options.SetActive(true);
    }

    public void Shop()
    {
        menu.SetActive(false);
        shop.SetActive(true);
    }

    public void Upgrades()
    {
        menu.SetActive(false);
        upgrades.SetActive(true);
    }

    public void Levels()
    {
        menu.SetActive(false);
        levels.SetActive(true);
    }

    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void InstructionsBack()
    {
        instructions.SetActive(false);
        menu.SetActive(true);
    }

    public void CreditsBack()
    {
        credits.SetActive(false);
        menu.SetActive(true);
    }

    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        pause.SetActive(false);
        ui.SetActive(false);
        menu.SetActive(true);
    }
}
