using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Toggle soundToggle;

    private const string SoundEnabledKey = "SoundEnabled";

    private void Start()
    {
        // �������������� ��������� ������������� �� ������ ����������� ��������
        bool soundEnabled = PlayerPrefs.GetInt(SoundEnabledKey, 1) == 1;
        soundToggle.isOn = soundEnabled;

        // ����������� ���������� ������� ��������� ��������� �������������
        soundToggle.onValueChanged.AddListener(OnSoundToggleValueChanged);
    }

    private void OnSoundToggleValueChanged(bool isOn)
    {
        // ��������� ��������� ������ � PlayerPrefs
        PlayerPrefs.SetInt(SoundEnabledKey, isOn ? 1 : 0);
        PlayerPrefs.Save();

        // �������� ��� ��������� ����� �� ������ ��������� �������������
        AudioListener.volume = isOn ? 1 : 0;
    }
}
