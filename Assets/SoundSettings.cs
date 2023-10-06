using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Toggle soundToggle;

    private const string SoundEnabledKey = "SoundEnabled";

    private void Start()
    {
        // Инициализируем состояние переключателя на основе сохраненных настроек
        bool soundEnabled = PlayerPrefs.GetInt(SoundEnabledKey, 1) == 1;
        soundToggle.isOn = soundEnabled;

        // Привязываем обработчик события изменения состояния переключателя
        soundToggle.onValueChanged.AddListener(OnSoundToggleValueChanged);
    }

    private void OnSoundToggleValueChanged(bool isOn)
    {
        // Сохраняем состояние звуков в PlayerPrefs
        PlayerPrefs.SetInt(SoundEnabledKey, isOn ? 1 : 0);
        PlayerPrefs.Save();

        // Включаем или отключаем звуки на основе состояния переключателя
        AudioListener.volume = isOn ? 1 : 0;
    }
}
