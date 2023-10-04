using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveSystem : MonoBehaviour
{
    int money;
    public static SaveSystem ss;

    private void Awake()
    {
        ss = GetComponent<SaveSystem>();
    }
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedMoney = GameManager.gameManager.money;
        data.record = GameManager.gameManager.record;
        data.currentSkin = GameManager.gameManager.currentSkin;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            GameManager.gameManager.money = data.savedMoney;
            GameManager.gameManager.record = data.record;
            GameManager.gameManager.currentSkin = data.currentSkin;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}

[Serializable]
class SaveData
{
    public int savedMoney;
    public int record;
    public int currentSkin;
}
