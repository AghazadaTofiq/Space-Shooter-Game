using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject menu;
    [SerializeField] private AudioSource music;

    public void Mute()
    {
        music.mute = true;
    }

    public void Back()
    {
        options.SetActive(false);
        menu.SetActive(true);
    }
}
