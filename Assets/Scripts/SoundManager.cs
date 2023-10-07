using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private bool isMusicEnabled = true; // По умолчанию музыка включена

    private AudioSource[] allAudioSources;

    private void Start()
    {
        // Находим все AudioSource на сцене
        allAudioSources = FindObjectsOfType<AudioSource>();

        ToggleMusic(); // Включаем или выключаем музыку в соответствии с начальным состоянием
    }

    public void ToggleMusic()
    {
        isMusicEnabled = !isMusicEnabled; // Инвертируем состояние музыки

        // Обходим все AudioSource и выключаем или включаем их
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.enabled = isMusicEnabled;
        }
    }

    public bool IsMusicEnabled()
    {
        return isMusicEnabled;
    }
}
