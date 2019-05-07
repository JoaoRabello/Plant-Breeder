using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour {

    public static SaveSystem instance;
    private string path;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        path = Application.persistentDataPath + "/save.dat";
        Debug.Log(Application.persistentDataPath);
        CheckSave();
    }

    private void CheckSave()
    {
        if(File.Exists(path) == false)
        {
            CreateSave();
        }
        else
        {
            LoadSave();
        }
    }

    private void CreateSave()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Open(path, FileMode.Create);

        SaveData newSaveData = new SaveData
        {
            currency = 0
        };

        binaryFormatter.Serialize(fileStream, newSaveData);
        fileStream.Close();
        LoadSave();
    }

    private void LoadSave()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Open(path, FileMode.Open);

        SaveData saveData = (SaveData)binaryFormatter.Deserialize(fileStream);
        fileStream.Close();

        PlantManager.instance.happinessCurrency = saveData.currency;
    }

    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Open(path, FileMode.Open);

        SaveData newSaveData = new SaveData()
        {
            currency = PlantManager.instance.happinessCurrency
        };

        binaryFormatter.Serialize(fileStream, newSaveData);
        fileStream.Close();
    }
}

[Serializable]
public class SaveData
{
    public int currency;
}
