using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Image buttonImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public SoundManager soundManager;

    private void Start()
    {
        UpdateButtonIcon();
    }

    public void OnSoundButtonClick()
    {
        soundManager.ToggleMusic();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (soundManager.IsMusicEnabled())
        {
            buttonImage.sprite = soundOnSprite;
        }
        else
        {
            buttonImage.sprite = soundOffSprite;
        }
    }
}

