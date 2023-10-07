using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private bool isMusicEnabled = true; // �� ��������� ������ ��������

    private AudioSource[] allAudioSources;

    private void Start()
    {
        // ������� ��� AudioSource �� �����
        allAudioSources = FindObjectsOfType<AudioSource>();

        ToggleMusic(); // �������� ��� ��������� ������ � ������������ � ��������� ����������
    }

    public void ToggleMusic()
    {
        isMusicEnabled = !isMusicEnabled; // ����������� ��������� ������

        // ������� ��� AudioSource � ��������� ��� �������� ��
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
