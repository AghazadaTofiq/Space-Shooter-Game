using UnityEngine;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject menu;
    [SerializeField] private TextMeshProUGUI muteText;
    [SerializeField] private AudioSource playSound;
    [SerializeField] private AudioSource uiSound;
    [SerializeField] private AudioSource shootSound;

    private bool muted = false;

    public void Mute()
    {
        if (muted)
        {
            playSound.mute = false;
            uiSound.mute = false;
            shootSound.mute = false;
            muted = false;
            muteText.text = "Mute";
        }
        else
        {
            playSound.mute = true;
            uiSound.mute = true;
            shootSound.mute = true;
            muted = true;
            muteText.text = "Muted";
        }

    }

    public void Back()
    {
        options.SetActive(false);
        menu.SetActive(true);
    }
}
